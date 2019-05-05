using System;
using System.Drawing;
using System.Windows.Forms;
using Helper;

using DevExpress.XtraTab;
using SQLDAL;
using SQLDAL.IDAL;
using SQLUserControl;
using System.Data;
using System.Collections.Generic;

namespace SQLClient
{

    public partial class SqlClientForm : DevExpress.XtraEditors.XtraForm
    {
        private LoadingForm waitForm = new LoadingForm();
        private TreeNode currentDbNode = null;
        private ViewListType currentViewListType = ViewListType.eNothing;
        private NewConnectionFrom newConnectionForm = null;
        public SqlClientForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true; 
        }
        private void SQLClientForm_Load(object sender, EventArgs e)
        {
            this.spStatusBar.SplitterDistance = this.spStatusBar.Height - 25;
            TabPageTypeInfo pageTypeInfo = new TabPageTypeInfo(TabPageType.eObject, null);
            this.tpObject.Tag = pageTypeInfo;
            this.ShowStatusBar(pageTypeInfo);
            List<ConnectionInfo> list = ConnectionInfo.LoadConnection($"Data Source = {Application.StartupPath}\\AppData\\JimoSQL.db");
            foreach(ConnectionInfo info in list)
            {
                TreeNode node = new TreeNode();
                node.Text = info.Name;
                node.ImageKey = Resource.image_key_connect_close;
                node.SelectedImageKey = Resource.image_key_connect_close;
                node.Tag = new NodeTypeInfo(NodeType.eConnect, node, info);
                this.tvMain.Nodes.Add(node);
                this.tsObjectBlank.Text = $"{this.tvMain.Nodes.Count}服务器";
            }
        }

        private void SQLClientForm_SizeChanged(object sender, EventArgs e)
        {
            this.ReSizeStatusBar();
        }

        private void ReSizeStatusBar()
        {
            this.tsObjectBlank.Width = this.tvMain.Width;
            this.tsOpenTableBlank.Width = this.tvMain.Width;
            this.tsNewSelectBlank.Width = this.tvMain.Width;
            this.tsDesignTableBlank.Width = this.tvMain.Width;
        }

        private void OpenNewConnectionForm(ConnectType type, string driver)
        {
            if (this.newConnectionForm == null)
            {
                this.newConnectionForm = new NewConnectionFrom();
                this.newConnectionForm.SqlClientForm = this;
            }
            this.newConnectionForm.Driver = driver;
            this.newConnectionForm.Type = type;
            this.newConnectionForm.ShowDialog();
        }

        private void btnNewJimoSQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OpenNewConnectionForm(ConnectType.eJimoSQL, "JimoSQL ODBC Unicode Driver");
        }
        private void btnNewMySQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OpenNewConnectionForm(ConnectType.eMySQL, "MySQL ODBC 8.0 Unicode Driver");
        }

        public void AddConnection(ConnectType type, string _name, string _host, int _port, string _user, string _password)
        {
            ConnectionInfo info = SQLDALHelper.GetConnectionInfo(type);
            info.Name = _name;
            info.Host = _host;
            info.Port = _port;
            info.User = _user;
            info.Password = _password;
            info.Type = (int)type;
            TreeNode node = new TreeNode();
            node.Text = _name;
            node.ImageKey = Resource.image_key_connect_close;
            node.SelectedImageKey = Resource.image_key_connect_close;
            node.Tag = new NodeTypeInfo(NodeType.eConnect, node, info);
            ConnectionInfo.AddConnection($"Data Source = {Application.StartupPath}\\AppData\\JimoSQL.db", info);
            this.tvMain.Nodes.Add(node);
            this.tsObjectBlank.Text = $"{this.tvMain.Nodes.Count}服务器";
            this.tsObjectOwner.Text = $"{_name} 用户: {_user}";
            this.tsObjectOwner.Image = Resource.server_close_16;
        }

        private void tvMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = this.tvMain.SelectedNode;
            NodeTypeInfo nodeTypeInfo = node.Tag as NodeTypeInfo;
            switch (nodeTypeInfo.NodeType)
            {
                case NodeType.eConnect:
                    {
                        ConnectionInfo info = nodeTypeInfo.ConnectionInfo;
                        if (info.IsOpen)
                        {
                            return;
                        }
                        AsyncHelper.AsyncHandlerArgs ah = new AsyncHelper.AsyncHandlerArgs(OpenConnect);
                        ah.BeginInvoke(nodeTypeInfo, null, null);
                        this.waitForm.ShowDialog();
                        break;
                    }
                case NodeType.eDatabase:
                    {
                        DatabaseInfo info = nodeTypeInfo.DatabaseInfo;
                        if (info.IsOpen)
                        {
                            return;
                        }
                        AsyncHelper.AsyncHandlerArgs ah = new AsyncHelper.AsyncHandlerArgs(OpenDatabase);
                        ah.BeginInvoke(nodeTypeInfo, null, null);
                        this.waitForm.ShowDialog();                    
                        break;
                    }
                case NodeType.eTableGroup:
                    {
                        this.currentDbNode = node.Parent;
                        break;
                    }
                case NodeType.eViewGroup:
                    {
                        this.currentDbNode = node.Parent;
                        break;
                    }
                case NodeType.eSelectGroup:
                    {
                        this.currentDbNode = node.Parent;
                        break;
                    }
                case NodeType.eTable:
                    {
                        TableInfo info = nodeTypeInfo.TableInfo;
                        if (info.IsOpen)
                        {
                            return;
                        }
                        
                        AsyncHelper.AsyncHandlerArgs ah = new AsyncHelper.AsyncHandlerArgs(OpenTable);
                        ah.BeginInvoke(info, null, null);
                        this.waitForm.ShowDialog();
                        
                        break;
                    }
                case NodeType.eView:
                    {
                        ViewInfo info = nodeTypeInfo.ViewInfo;
                        if (info.IsOpen)
                        {
                            return;
                        }

                        AsyncHelper.AsyncHandlerArgs ah = new AsyncHelper.AsyncHandlerArgs(OpenView);
                        ah.BeginInvoke(info, null, null);
                        this.waitForm.ShowDialog();
                        break;
                    }
                case NodeType.eSelect:
                    {
                        SelectInfo info = nodeTypeInfo.SelectInfo;
                        if (info.IsOpen)
                        {
                            return;
                        }
                        AsyncHelper.AsyncHandlerArgs ah = new AsyncHelper.AsyncHandlerArgs(OpenSelect);
                        ah.BeginInvoke(info, null, null);
                        this.waitForm.ShowDialog();
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private void OpenDatabase(object args)
        {
            NodeTypeInfo nodeTypeInfo = args as NodeTypeInfo;
            DatabaseInfo info = nodeTypeInfo.DatabaseInfo;
            TreeNode node = nodeTypeInfo.Node;
            info.ConnectionInfo.UseDatabase(info.Name);
            info.Open();
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                this.tvMain.BeginUpdate();
                //add table group node
                TreeNode tgNode = new TreeNode();
                NodeTypeInfo tgNodeTypeInfo = new NodeTypeInfo(NodeType.eTableGroup, tgNode);
                tgNode.Text = Resource.node_name_table;
                tgNode.ImageKey = Resource.image_key_table;
                tgNode.SelectedImageKey = Resource.image_key_table;
                tgNode.Tag = tgNodeTypeInfo;
                node.Nodes.Add(tgNode);

                //add table node and add table listview
                tgNodeTypeInfo.TableList = new TableListView();
                tgNodeTypeInfo.TableList.OpenTable += TableList_OpenTable;
                tgNodeTypeInfo.TableList.DesignTable += TableList_DesignTable;
                tgNodeTypeInfo.TableList.SmallImageList = this.imgListListView;
                tgNodeTypeInfo.TableList.Dock = DockStyle.Fill;
                tgNodeTypeInfo.TableList.View = View.List;
                tgNodeTypeInfo.TableList.Visible = false;
                tgNodeTypeInfo.TableList.LabelEdit = true;
                tgNodeTypeInfo.TableList.Tag = tgNodeTypeInfo;
                tgNodeTypeInfo.TableList.DatabaseInfo = info;
                this.tpObject.Controls.Add(tgNodeTypeInfo.TableList);
                foreach (TableInfo tbInfo in info.Tables)
                {
                    TreeNode tbNode = new TreeNode();
                    tbNode.Text = tbInfo.Name;
                    tbNode.ImageKey = Resource.image_key_table;
                    tbNode.SelectedImageKey = Resource.image_key_table;
                    tbNode.Tag = new NodeTypeInfo(NodeType.eTable, tbNode, tbInfo);
                    tgNode.Nodes.Add(tbNode);
                    tgNodeTypeInfo.TableList.AddItem(tbInfo, Resource.image_key_table);
                }

                //add view group node
                TreeNode vgpNode = new TreeNode();
                NodeTypeInfo vgNodeTypeInfo = new NodeTypeInfo(NodeType.eViewGroup, vgpNode);
                vgpNode.Text = Resource.node_name_view;
                vgpNode.ImageKey = Resource.image_key_view;
                vgpNode.SelectedImageKey = Resource.image_key_view;
                vgpNode.Tag = vgNodeTypeInfo;
                node.Nodes.Add(vgpNode);

                //add view node and view listview
                vgNodeTypeInfo.ViewList = new ViewListView();
                vgNodeTypeInfo.ViewList.SmallImageList = this.imgListListView;
                vgNodeTypeInfo.ViewList.Dock = DockStyle.Fill;
                vgNodeTypeInfo.ViewList.View = View.List;
                vgNodeTypeInfo.ViewList.Visible = false;
                vgNodeTypeInfo.ViewList.Tag = vgNodeTypeInfo;
                vgNodeTypeInfo.ViewList.DatabaseInfo = info;
                this.tpObject.Controls.Add(vgNodeTypeInfo.ViewList);
                foreach (ViewInfo vInfo in info.Views)
                {
                    TreeNode vNode = new TreeNode();
                    vNode.Text = vInfo.Name;
                    vNode.ImageKey = Resource.image_key_view;
                    vNode.SelectedImageKey = Resource.image_key_view;
                    vNode.Tag = new NodeTypeInfo(NodeType.eView, vNode, vInfo);
                    vgpNode.Nodes.Add(vNode);
                    vgNodeTypeInfo.ViewList.AddItem(vInfo, Resource.image_key_view);
                }

                //add select group
                TreeNode sgNode = new TreeNode();
                NodeTypeInfo sgNodeTypeInfo = new NodeTypeInfo(NodeType.eSelectGroup, sgNode);
                sgNode.Text = Resource.node_name_select;
                sgNode.ImageKey = Resource.image_key_select;
                sgNode.SelectedImageKey = Resource.image_key_select;
                sgNode.Tag = sgNodeTypeInfo;
                node.Nodes.Add(sgNode);

                //add select node and select listview
                sgNodeTypeInfo.SelectList = new SelectListView();
                sgNodeTypeInfo.SelectList.DatabaseInfo = info;
                sgNodeTypeInfo.SelectList.NewSelect += SelectList_NewSelect;
                sgNodeTypeInfo.SelectList.SmallImageList = this.imgListListView;
                sgNodeTypeInfo.SelectList.Dock = DockStyle.Fill;
                sgNodeTypeInfo.SelectList.View = View.List;
                sgNodeTypeInfo.SelectList.Visible = false;
                sgNodeTypeInfo.SelectList.Tag = sgNodeTypeInfo;
                sgNodeTypeInfo.SelectList.DatabaseInfo = info;
                this.tpObject.Controls.Add(sgNodeTypeInfo.SelectList);
                foreach (SelectInfo sInfo in info.Selects)
                {
                    TreeNode sNode = new TreeNode();
                    sNode.Text = sInfo.Name;
                    sNode.ImageKey = Resource.image_key_select;
                    sNode.SelectedImageKey = Resource.image_key_select;
                    sNode.Tag = new NodeTypeInfo(NodeType.eSelect, sNode, sInfo);
                    sgNode.Nodes.Add(sNode);
                    sgNodeTypeInfo.SelectList.AddItem(sInfo, Resource.image_key_select);
                }
                this.tvMain.EndUpdate();
                node.ImageKey = Resource.image_key_database_open;
                node.SelectedImageKey = Resource.image_key_database_open;
                node.Expand();
                nodeTypeInfo.TableList = tgNodeTypeInfo.TableList;
                nodeTypeInfo.ViewList = vgNodeTypeInfo.ViewList;
                nodeTypeInfo.SelectList = sgNodeTypeInfo.SelectList;

                if (this.currentViewListType == ViewListType.eNothing)
                {
                    this.currentViewListType = ViewListType.eTable;
                }
                //this.currentDbNode = node;
                this.SelectDbNode(node, this.currentViewListType, true);
                this.SelectToolBar();
                nodeTypeInfo.TableList.UnSelectItem();
                nodeTypeInfo.ViewList.UnSelectItem();
                nodeTypeInfo.SelectList.UnSelectItem();
                this.tsObjectBlank.Text = $"{info.Tables.Count}表({info.Tables.Count}位于当前的组)";
                this.tsObjectOwner.Text = $"{info.ConnectionInfo.Name} 用户:{info.ConnectionInfo.User} 数据库:{info.Name}";
                this.tsObjectOwner.Image = Resource.server_open_16;
                this.waitForm.Close();
            }));
        }

        private void TableList_OpenTable(object sender, OpenTabletEventArgs e)
        {
            TableInfo info = e.Item.Tag as TableInfo;
            if (info.IsOpen)
            {
                return;
            }

            AsyncHelper.AsyncHandlerArgs ah = new AsyncHelper.AsyncHandlerArgs(OpenTable);
            ah.BeginInvoke(info, null, null);
            this.waitForm.ShowDialog();
        }

        private void TableList_DesignTable(object sender, DesignTabletEventArgs e)
        {
            TableInfo info = e.Item.Tag as TableInfo;
            XtraTabPage tabPage = new XtraTabPage();
            tabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            tabPage.Text = $"{info.Name}@{info.DatabaseInfo.Name}({info.ConnectionInfo.Name})-表";
            tabPage.Tooltip = tabPage.Text;
            tabPage.MaxTabPageWidth = 200;
            tabPage.Image = Resource.design_table_16;

            //new DesignTableTabPage
            DesignTablePage designTablePage = new DesignTablePage();
            designTablePage.Dock = DockStyle.Fill;
            designTablePage.TableInfo = info;
            designTablePage.FieldsInfo = this.tsFields;
            designTablePage.IndexsInfo = this.tsIndexs;
            designTablePage.PrimaryKeysInfo = this.tsPrimaryKeys;
            designTablePage.TriggersInfo = this.tsTriggers;
            designTablePage.BindData();

            TabPageTypeInfo tpInfo = new TabPageTypeInfo(TabPageType.eDesignTable, info);
            tpInfo.DesignTablePage = designTablePage;
            tabPage.Tag = tpInfo;

            tabPage.Controls.Add(designTablePage);

            this.tcMain.TabPages.Add(tabPage);
            this.tcMain.SelectedTabPage = tabPage;
        }

        private void SelectList_NewSelect(object sender, NewSelectEventArgs e)
        {
            DatabaseInfo databaseInfo = e.DatabaseInfo;
            XtraTabPage tabPage = new XtraTabPage();
            tabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            tabPage.Text = $"无标题@{databaseInfo.Name}({databaseInfo.ConnectionInfo.Name})-查询";
            tabPage.Tooltip = tabPage.Text;
            tabPage.MaxTabPageWidth = 200;
            tabPage.Image = Resource.select_16;

            //new NewSelectTabPage
            NewSelectPage newSelectPage = new NewSelectPage();
            newSelectPage.Dock = DockStyle.Fill;
            newSelectPage.DatabaseInfo = databaseInfo;
            newSelectPage.Statement = this.tsOpenTableStmt;
            newSelectPage.PageInfo = this.tsOpenTablePageInfo;
            newSelectPage.TimeInfo = this.tsNewSelectTime;

            TabPageTypeInfo tpInfo = new TabPageTypeInfo(TabPageType.eNewSelect, databaseInfo);
            tpInfo.NewSelectPage = newSelectPage;
            tabPage.Tag = tpInfo;
            
            tabPage.Controls.Add(newSelectPage);

            this.tcMain.TabPages.Add(tabPage);
            this.tcMain.SelectedTabPage = tabPage;
        }

        private void OpenConnect(object args)
        {
            NodeTypeInfo nodeTypeInfo = args as NodeTypeInfo;
            ConnectionInfo info = nodeTypeInfo.ConnectionInfo;
            TreeNode node = nodeTypeInfo.Node;
            bool success = info.Open();
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (!success)
                {
                    this.waitForm.Close();
                    MessageBox.Show(info.Message);
                    return;
                }
                this.tvMain.BeginUpdate();
                foreach (DatabaseInfo dbInfo in info.Databases)
                {
                    TreeNode dbNode = new TreeNode();
                    dbNode.Text = dbInfo.Name;
                    dbNode.ImageKey = Resource.image_key_database_close;
                    dbNode.SelectedImageKey = Resource.image_key_database_close;
                    dbNode.Tag = new NodeTypeInfo(NodeType.eDatabase, dbNode, dbInfo);
                    node.Nodes.Add(dbNode);
                }
                this.tvMain.EndUpdate();
                node.ImageKey = Resource.image_key_connect_open;
                node.SelectedImageKey = Resource.image_key_connect_open;
                node.Expand();
                this.waitForm.Close();
                this.tsObjectBlank.Text = $"{info.Databases.Count}数据据库";
                this.tsObjectOwner.Text = $"{info.Name} 用户: {info.User}";
                this.tsObjectOwner.Image = Resource.server_open_16;
            }));
        }
        private void OpenTable(object args)
        {
            try
            {
                TableInfo info = args as TableInfo;
                bool success = info.Open(0);
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    if (!success)
                    {
                        this.waitForm.Close();
                        MessageBox.Show(info.Message);
                        return;
                    }
                    //add TabPage
                    XtraTabPage tabPage = new XtraTabPage();
                    tabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    tabPage.Text = $"{info.Name}@{info.DatabaseInfo.Name}({info.ConnectionInfo.Name})-表";
                    tabPage.Tooltip = tabPage.Text;
                    tabPage.MaxTabPageWidth = 200;
                    //new OpenTableTabPage
                    OpenTablePage openTalePage = new OpenTablePage();
                    openTalePage.Dock = DockStyle.Fill;
                    openTalePage.TableInfo = info;
                    openTalePage.Statement = this.tsOpenTableStmt;
                    openTalePage.PageInfo = this.tsOpenTablePageInfo;
                    openTalePage.BindData(0);

                    TabPageTypeInfo tpInfo = new TabPageTypeInfo(TabPageType.eOpenTable, info);
                    tpInfo.OpenTablePage = openTalePage;
                    tabPage.Tag = tpInfo;
                    tabPage.Image = Resource.table_16;
                    tabPage.Controls.Add(openTalePage);

                    this.tcMain.TabPages.Add(tabPage);
                    this.tcMain.SelectedTabPage = tabPage;
                    this.waitForm.Close();
                }));
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }
        private void OpenSelect(object args)
        {
            try
            {
                SelectInfo info = args as SelectInfo;
                bool success = info.Open();
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    if (!success)
                    {
                        this.waitForm.Close();
                        MessageBox.Show(info.Message);
                        return;
                    }
                    //add TabPage
                    XtraTabPage tabPage = new XtraTabPage();
                    tabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    tabPage.Text = $"{info.Name}@{info.DatabaseInfo.Name}({info.ConnectionInfo.Name})-查询";
                    tabPage.Tooltip = tabPage.Text;
                    tabPage.MaxTabPageWidth = 200;
                    //new OpenTableTabPage
                    NewSelectPage newSelectPage = new NewSelectPage();
                    newSelectPage.Dock = DockStyle.Fill;
                    newSelectPage.SelectInfo = info;
                    newSelectPage.Statement = this.tsOpenTableStmt;
                    newSelectPage.PageInfo = this.tsOpenTablePageInfo;
                    newSelectPage.BindData();

                    TabPageTypeInfo tpInfo = new TabPageTypeInfo(TabPageType.eNewSelect, info);
                    tpInfo.NewSelectPage = newSelectPage;
                    tabPage.Tag = tpInfo;
                    tabPage.Image = Resource.select_16;
                    tabPage.Controls.Add(newSelectPage);

                    this.tcMain.TabPages.Add(tabPage);
                    this.tcMain.SelectedTabPage = tabPage;
                    this.waitForm.Close();
                }));
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }
        private void OpenView(object args)
        {
            try
            {
                ViewInfo info = args as ViewInfo;
                bool success = info.Open(0);
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    if (!success)
                    {
                        this.waitForm.Close();
                        MessageBox.Show(info.Message);
                        return;
                    }
                    //add TabPage
                    XtraTabPage tabPage = new XtraTabPage();
                    tabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    tabPage.Text = $"{info.Name}@{info.DatabaseInfo.Name}({info.ConnectionInfo.Name})-视图";
                    tabPage.Tooltip = tabPage.Text;
                    tabPage.MaxTabPageWidth = 200;
                    //new OpenTableTabPage
                    OpenViewPage openViewPage = new OpenViewPage();
                    openViewPage.Dock = DockStyle.Fill;
                    openViewPage.ViewInfo = info;
                    openViewPage.OpenTableStatement = this.tsOpenTableStmt;
                    openViewPage.OpenTablePageInfo = this.tsOpenTablePageInfo;
                    openViewPage.BindData(0);

                    TabPageTypeInfo tpInfo = new TabPageTypeInfo(TabPageType.eOpenView, info);
                    tpInfo.OpenViewPage = openViewPage;
                    tabPage.Tag = tpInfo;
                    tabPage.Image = Resource.view_16;
                    tabPage.Controls.Add(openViewPage);

                    this.tcMain.TabPages.Add(tabPage);
                    this.tcMain.SelectedTabPage = tabPage;
                    this.waitForm.Close();
                }));
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }
        private void tcMain_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs args = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            foreach (XtraTabPage page in this.tcMain.TabPages)
            {
                if (args.Page.Text == page.Text)
                {
                    TabPageTypeInfo pageTypeInfo = page.Tag as TabPageTypeInfo;
                    switch(pageTypeInfo.PageType)
                    {
                        case TabPageType.eOpenTable:
                            {
                                TableInfo info = pageTypeInfo.Info as TableInfo;
                                info.Close();
                                break;
                            }
                        case TabPageType.eOpenView:
                            {
                                ViewInfo info = pageTypeInfo.Info as ViewInfo;
                                info.Close();
                                break;
                            }
                        case TabPageType.eOpenSelect:
                            {
                                break;
                            }
                        case TabPageType.eDesignTable:
                            {
                                break;
                            }
                        case TabPageType.eDesignView:
                            {
                                break;
                            }
                        case TabPageType.eNewTable:
                            {
                                break;
                            }
                        case TabPageType.eNewView:
                            {
                               
                                break;
                            }
                        case TabPageType.eNewSelect:
                            {
                                SelectInfo info = pageTypeInfo.Info as SelectInfo;
                                if (info != null)
                                {
                                    info.Close();
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    this.tcMain.TabPages.Remove(page);
                    break;
                }
            }
            this.tcMain.SelectedTabPage = this.tcMain.TabPages[this.tcMain.TabPages.Count - 1];
            if (this.tcMain.SelectedTabPageIndex == 0)
            {
                TabPageTypeInfo pageTypeInfo = this.tcMain.SelectedTabPage.Tag as TabPageTypeInfo;
                this.ShowStatusBar(pageTypeInfo);
            }
        }

        private void tcMain_Selected(object sender, TabPageEventArgs e)
        {
            TabPageTypeInfo pageTypeInfo = e.Page.Tag as TabPageTypeInfo;
            this.ShowStatusBar(pageTypeInfo);
        }

        private void ShowStatusBar(TabPageTypeInfo pageTypeInfo)
        {
            switch(pageTypeInfo.PageType)
            {
                case TabPageType.eObject:
                    {
                        this.tsObject.Visible = true;
                        this.tsOpenTable.Visible = false;
                        this.tsDesignTable.Visible = false;
                        this.tsNewSelect.Visible = false;


                        TreeNode selectNode = this.tvMain.SelectedNode;
                        if (selectNode == null)
                        {
                            return;
                        }
                        this.SelectNode(selectNode);
                        break;
                    }
                case TabPageType.eOpenTable:
                    {
                        this.tsObject.Visible = false;
                        this.tsOpenTable.Visible = true;
                        this.tsDesignTable.Visible = false;
                        this.tsNewSelect.Visible = false;
                        pageTypeInfo.OpenTablePage.SetStatusBar();
                        break;
                    }
                case TabPageType.eOpenView:
                    {
                        this.tsObject.Visible = false;
                        this.tsOpenTable.Visible = true;
                        this.tsDesignTable.Visible = false;
                        this.tsNewSelect.Visible = false;

                        pageTypeInfo.OpenViewPage.SetStatusBar();
                        break;
                    }
                case TabPageType.eOpenSelect:
                    {
                        this.tsObject.Visible = false;
                        this.tsOpenTable.Visible = false;
                        this.tsDesignTable.Visible = false;
                        this.tsNewSelect.Visible = true;
                        break;
                    }
                case TabPageType.eNewTable:
                    {
                        break;
                    }
                case TabPageType.eNewView:
                    {
                        break;
                    }
                case TabPageType.eNewSelect:
                    {
                        this.tsObject.Visible = false;
                        this.tsOpenTable.Visible = false;
                        this.tsDesignTable.Visible = false;
                        this.tsNewSelect.Visible = true;
                        pageTypeInfo.NewSelectPage.SetStatusBar();
                        break;
                    }
                case TabPageType.eDesignTable:
                    {
                        this.tsObject.Visible = false;
                        this.tsOpenTable.Visible = false;
                        this.tsDesignTable.Visible = true;
                        this.tsNewSelect.Visible = false;
                        pageTypeInfo.DesignTablePage.SetStatusBar();
                        break;
                    }
                case TabPageType.eDesignView:
                    {
                        break;
                    }
            }
        }

        private void SelectNode(TreeNode node)
        {
            NodeTypeInfo nodeTypeInfo = node.Tag as NodeTypeInfo;
            switch (nodeTypeInfo.NodeType)
            {
                case NodeType.eConnect:
                    {
                        this.currentDbNode = null;
                        ConnectionInfo connectInfo = nodeTypeInfo.ConnectionInfo;
                        if (!connectInfo.IsOpen)
                        {
                            this.tsObjectBlank.Text = $"{this.tvMain.Nodes.Count}服务器";
                            this.tsObjectOwner.Text = $"{connectInfo.Name} 用户: {connectInfo.User}";
                            this.tsObjectOwner.Image = Resource.server_close_16;
                            return;
                        }
                        foreach (Control c in this.tpObject.Controls)
                        {
                            if (c is TableListView || c is SelectListView || c is ViewListView)
                            {
                                c.Visible = false;
                            }
                            if (c is ToolStrip)
                            {
                                c.Enabled = false;
                            }
                        }
                        this.tsObjectBlank.Text = $"{connectInfo.Databases.Count}数据据库";
                        this.tsObjectOwner.Text = $"{connectInfo.Name} 用户: {connectInfo.User}";
                        this.tsObjectOwner.Image = Resource.server_open_16;
                        break;
                    }
                case NodeType.eDatabase:
                    {
                        //this.currentDbNode = node;
                        this.SelectDbNode(node, this.currentViewListType);
                        DatabaseInfo databaseInfo = nodeTypeInfo.DatabaseInfo;
                        if (!databaseInfo.IsOpen)
                        {
                            ConnectionInfo connectInfo = databaseInfo.ConnectionInfo;
                            this.tsObjectBlank.Text = $"{connectInfo.Databases.Count}数据库";
                            this.tsObjectOwner.Text = $"{connectInfo.Name} 用户: {connectInfo.User} 数据库:{databaseInfo.Name}";
                            this.tsObjectOwner.Image = Resource.server_open_16;
                            return;
                        }
                        nodeTypeInfo.TableList.UnSelectItem();
                        nodeTypeInfo.ViewList.UnSelectItem();
                        nodeTypeInfo.SelectList.UnSelectItem();
                        //handle select tool bar
                        this.SelectToolBar();

                        //handle left status bar
                        this.tsObjectBlank.Text = $"{databaseInfo.Tables.Count}表({databaseInfo.Tables.Count}位于当前的组)";
                        this.tsObjectOwner.Text = $"{databaseInfo.ConnectionInfo.Name} 用户:{databaseInfo.ConnectionInfo.User} 数据库:{databaseInfo.Name}";
                        this.tsObjectOwner.Image = Resource.server_open_16;
                        break;
                    }
                case NodeType.eTableGroup:
                    {
                        //show table view list
                        this.SelectDbNode(node.Parent, ViewListType.eTable);

                        //handle selectt tool bar
                        this.SelectToolBar();

                        //handle left status bar
                        NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                        dbNodeTypeInfo.TableList.UnSelectItem();
                        DatabaseInfo databaseInfo = dbNodeTypeInfo.DatabaseInfo;
                        this.tsObjectBlank.Text = $"{databaseInfo.Tables.Count}表({databaseInfo.Tables.Count}位于当前的组)";
                        this.tsObjectOwner.Text = $"{databaseInfo.ConnectionInfo.Name} 用户:{databaseInfo.ConnectionInfo.User} 数据库:{databaseInfo.Name}";
                        this.tsObjectOwner.Image = Resource.server_open_16;
                        break;
                    }
                case NodeType.eTable:
                    {
                        //show table view list
                        this.SelectDbNode(node.Parent.Parent, ViewListType.eTable);

                        //handle select tool bar
                        this.SelectToolBar();
                        //handle left status bar
                        NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                        dbNodeTypeInfo.TableList.SelectItem();
                        DatabaseInfo databaseInfo = dbNodeTypeInfo.DatabaseInfo;
                        this.tsObjectBlank.Text = $"{databaseInfo.Tables.Count}表({databaseInfo.Tables.Count}位于当前的组)";
                        this.tsObjectOwner.Text = $"{databaseInfo.ConnectionInfo.Name} 用户:{databaseInfo.ConnectionInfo.User} 数据库:{databaseInfo.Name}";
                        this.tsObjectOwner.Image = Resource.server_open_16;
                        break;
                    }
                case NodeType.eViewGroup:
                    {
                        //show view view list
                        this.SelectDbNode(node.Parent, ViewListType.eView);

                        //handle select tool bar
                        this.SelectToolBar();
                        //handle left status bar
                        NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                        dbNodeTypeInfo.ViewList.UnSelectItem();
                        DatabaseInfo databaseInfo = dbNodeTypeInfo.DatabaseInfo;
                        this.tsObjectBlank.Text = $"{databaseInfo.Views.Count}视图({databaseInfo.Views.Count}位于当前的组)";
                        this.tsObjectOwner.Text = $"{databaseInfo.ConnectionInfo.Name} 用户:{databaseInfo.ConnectionInfo.User} 数据库:{databaseInfo.Name}";
                        this.tsObjectOwner.Image = Resource.server_open_16;
                        break;
                    }
                case NodeType.eView:
                    {
                        //show view view list
                        this.SelectDbNode(node.Parent.Parent, ViewListType.eView);

                        //handle select tool bar
                        this.SelectToolBar();
                        //handle left status bar
                        NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                        dbNodeTypeInfo.ViewList.SelectItem();
                        DatabaseInfo databaseInfo = dbNodeTypeInfo.DatabaseInfo;
                        this.tsObjectBlank.Text = $"{databaseInfo.Views.Count}视图({databaseInfo.Views.Count}位于当前的组)";
                        this.tsObjectOwner.Text = $"{databaseInfo.ConnectionInfo.Name} 用户:{databaseInfo.ConnectionInfo.User} 数据库:{databaseInfo.Name}";
                        this.tsObjectOwner.Image = Resource.server_open_16;
                        break;
                    }
                case NodeType.eSelectGroup:
                    {
                        //show select view list
                        this.SelectDbNode(node.Parent, ViewListType.eSelect);

                        //handle select tool bar
                        this.SelectToolBar();
                        //handle left status bar
                        NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                        dbNodeTypeInfo.SelectList.UnSelectItem();
                        DatabaseInfo databaseInfo = dbNodeTypeInfo.DatabaseInfo;
                        this.tsObjectBlank.Text = $"{databaseInfo.Selects.Count}查询({databaseInfo.Selects.Count}位于当前的组)";
                        this.tsObjectOwner.Text = $"{databaseInfo.ConnectionInfo.Name} 用户:{databaseInfo.ConnectionInfo.User} 数据库:{databaseInfo.Name}";
                        this.tsObjectOwner.Image = Resource.server_open_16;

                        break;
                    }
                case NodeType.eSelect:
                    {
                        //show select view list
                        this.SelectDbNode(node.Parent.Parent, ViewListType.eSelect);

                        //handle select tool bar
                        this.SelectToolBar();

                        //handle left status bar
                        NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                        dbNodeTypeInfo.SelectList.SelectItem();
                        DatabaseInfo databaseInfo = dbNodeTypeInfo.DatabaseInfo;
                        this.tsObjectBlank.Text = $"{databaseInfo.Selects.Count}查询({databaseInfo.Selects.Count}位于当前的组)";
                        this.tsObjectOwner.Text = $"{databaseInfo.ConnectionInfo.Name} 用户:{databaseInfo.ConnectionInfo.User} 数据库:{databaseInfo.Name}";
                        this.tsObjectOwner.Image = Resource.server_open_16;

                        break;
                    }
            }
        }

        private void tvMain_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = this.tvMain.GetNodeAt(e.X, e.Y);
            if (node == null)
            {
                return;
            }
            this.SelectNode(node);
        }

        private void tvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            NodeTypeInfo nodeTypeInfo = node.Tag as NodeTypeInfo;
            switch (nodeTypeInfo.NodeType)
            {
                case NodeType.eConnect:
                    {
                        break;
                    }
                case NodeType.eDatabase:
                    {
                        break;
                    }
                case NodeType.eTableGroup:
                    {
                       
                        break;
                    }
                case NodeType.eTable:
                    {
                        break;
                    }
                case NodeType.eViewGroup:
                    {
                        
                        break;
                    }
                case NodeType.eView:
                    {
                      
                        break;
                    }
                case NodeType.eSelectGroup:
                    {
                       
                        break;
                    }
                case NodeType.eSelect:
                    {
                        
                        break;
                    }
            }
        }
        private void tvMain_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.Node.EndEdit(true);
            this.tvMain.LabelEdit = false;
        }

        private void tvMain_Leave(object sender, EventArgs e)
        {
            if (this.tvMain.SelectedNode == null)
            {
                return;
            }
            TreeNode node = this.tvMain.SelectedNode;
            NodeTypeInfo nodeTypeInfo = node.Tag as NodeTypeInfo;
            switch (nodeTypeInfo.NodeType)
            {
                case NodeType.eConnect:
                    {
                        break;
                    }
                case NodeType.eDatabase:
                    {
                        break;
                    }
                case NodeType.eSelect:
                    {
                        NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                        dbNodeTypeInfo.SelectList.UnSelectItem();
                        break;
                    }
                case NodeType.eSelectGroup:
                    {
                        break;
                    }
                case NodeType.eTable:
                    {
                        NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                        dbNodeTypeInfo.TableList.UnSelectItem();
                        break;
                    }
                case NodeType.eTableGroup:
                    {

                        break;
                    }
                case NodeType.eView:
                    {
                        NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                        dbNodeTypeInfo.ViewList.UnSelectItem();
                        break;
                    }
                case NodeType.eViewGroup:
                    {
                        break;
                    }
            }
        }

        private void SelectUserToolBar()
        {

        }

        private void SelectToolBar()
        {
            switch(this.currentViewListType)
            {
                case ViewListType.eTable:
                    {
                        this.tsbtnTable.Checked = true;
                        this.tsbtnView.Checked = false;
                        this.tsbtnSelect.Checked = false;
                        break;
                    }
                case ViewListType.eView:
                    {
                        this.tsbtnTable.Checked = false;
                        this.tsbtnView.Checked = true;
                        this.tsbtnSelect.Checked = false;
                        break;
                    }
                case ViewListType.eSelect:
                    {
                        this.tsbtnTable.Checked = false;
                        this.tsbtnView.Checked = false;
                        this.tsbtnSelect.Checked = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void SelectDbNode(TreeNode node, ViewListType type, bool isopen = false)
        {
            if ((this.currentDbNode != null && this.currentDbNode.Text != node.Text) || this.currentViewListType != type || isopen)
            {
                this.currentDbNode = node;
                this.currentViewListType = type;
                switch (this.currentViewListType)
                {
                    case ViewListType.eTable:
                        {
                            if (this.currentDbNode != null && this.currentDbNode.Nodes.Count > 0)
                            {
                                this.tvMain.SelectedNode = this.currentDbNode.Nodes[0];
                                NodeTypeInfo nodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                                foreach (Control c in this.tpObject.Controls)
                                {
                                    if (c is TableListView || c is SelectListView || c is ViewListView)
                                    {
                                        c.Visible = false;
                                    }
                                }
                                nodeTypeInfo.TableList.Visible = true;
                                nodeTypeInfo.TableList.BringToFront();
                            }
                            break;
                        }
                    case ViewListType.eView:
                        {
                            if (this.currentDbNode != null && this.currentDbNode.Nodes.Count > 0)
                            {
                                this.tvMain.SelectedNode = this.currentDbNode.Nodes[1];
                                NodeTypeInfo nodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                                foreach (Control c in this.tpObject.Controls)
                                {
                                    if (c is TableListView || c is SelectListView || c is ViewListView)
                                    {
                                        c.Visible = false;
                                    }
                                }
                                nodeTypeInfo.ViewList.Visible = true;
                                nodeTypeInfo.ViewList.BringToFront();
                            }
                            break;
                        }
                    case ViewListType.eSelect:
                        {
                            if (this.currentDbNode != null && this.currentDbNode.Nodes.Count > 0)
                            {
                                this.tvMain.SelectedNode = this.currentDbNode.Nodes[2];
                                NodeTypeInfo nodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
                                foreach (Control c in this.tpObject.Controls)
                                {
                                    if (c is TableListView || c is SelectListView || c is ViewListView)
                                    {
                                        c.Visible = false;
                                    }
                                }
                                nodeTypeInfo.SelectList.Visible = true;
                                nodeTypeInfo.SelectList.BringToFront();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            
        }

        private void tsbtnUser_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnTable_Click(object sender, EventArgs e)
        {
            if (this.currentDbNode == null)
            {
                return;
            }
            NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
            if (dbNodeTypeInfo == null)
            {
                return;
            }
            this.SelectDbNode(this.currentDbNode, ViewListType.eTable);
            this.currentViewListType = ViewListType.eTable;
            this.SelectToolBar();
            dbNodeTypeInfo.TableList.UnSelectItem();
        }

        private void tsbtnView_Click(object sender, EventArgs e)
        {
            if (this.currentDbNode == null)
            {
                return;
            }
            NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
            if (dbNodeTypeInfo == null)
            {
                return;
            }
            this.SelectDbNode(this.currentDbNode, ViewListType.eView);
            this.currentViewListType = ViewListType.eView;
            this.SelectToolBar();

            dbNodeTypeInfo.ViewList.UnSelectItem();
        }

        private void tsbtnSelect_Click(object sender, EventArgs e)
        {
            if (this.currentDbNode == null)
            {
                return;
            }
            NodeTypeInfo dbNodeTypeInfo = this.currentDbNode.Tag as NodeTypeInfo;
            if (dbNodeTypeInfo == null)
            {
                return;
            }
            this.SelectDbNode(this.currentDbNode, ViewListType.eSelect);
            this.currentViewListType = ViewListType.eSelect;
            this.SelectToolBar();

            dbNodeTypeInfo.SelectList.UnSelectItem();
        }

        private void tsmJimoSQL_Click(object sender, EventArgs e)
        {
            this.OpenNewConnectionForm(ConnectType.eJimoSQL, "JimoSQL ODBC Unicode Driver");
        }

        private void tsmMySQL_Click(object sender, EventArgs e)
        {
            this.OpenNewConnectionForm(ConnectType.eMySQL, "MySQL ODBC 8.0 Unicode Driver");
        }

        private void spMain_SplitterMoved(object sender, EventArgs e)
        {
            this.ReSizeStatusBar();
        }


    }
}
