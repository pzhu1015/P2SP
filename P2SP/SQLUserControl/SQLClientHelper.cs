using System.Windows.Forms;

using SQLDAL.IDAL;
using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.LookAndFeel;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

using DevExpress.CodeParser;
using DevExpress.Skins;

namespace SQLUserControl
{
    

    public enum ViewListType
    {
        eNothing,
        eTable,
        eView,
        eSelect
    }


    public enum NodeType
    {
        eConnect,
        eDatabase,
        eTableGroup,
        eTable,
        eViewGroup,
        eView,
        eSelectGroup,
        eSelect
    }

    public class NodeTypeInfo
    {
        public NodeTypeInfo(NodeType type, TreeNode node)
        {
            this.NodeType = type;
            this.Node = node;
        }

        public NodeTypeInfo(NodeType type, TreeNode node, ConnectionInfo info)
        {
            this.NodeType = type;
            this.Node = node;
            this.ConnectionInfo = info;
        }

        public NodeTypeInfo(NodeType type, TreeNode node, DatabaseInfo info)
        {
            this.NodeType = type;
            this.Node = node;
            this.DatabaseInfo = info;
        }

        public NodeTypeInfo(NodeType type, TreeNode node, TableInfo info)
        {
            this.NodeType = type;
            this.Node = node;
            this.TableInfo = info;
        }

        public NodeTypeInfo(NodeType type, TreeNode node, ViewInfo info)
        {
            this.NodeType = type;
            this.Node = node;
            this.ViewInfo = info;
        }

        public NodeTypeInfo(NodeType type, TreeNode node, SelectInfo info)
        {
            this.NodeType = type;
            this.Node = node;
            this.SelectInfo = info;
        }

        public NodeType NodeType { get; set; }
        public ConnectionInfo ConnectionInfo { get; set; }
        public DatabaseInfo DatabaseInfo { get; set; }
        public TableInfo TableInfo { get; set; }
        public ViewInfo ViewInfo { get; set; }
        public SelectInfo SelectInfo { get; set; }
        public TreeNode Node { get; set; }
        public TableListView TableList { get; set; }
        public ViewListView ViewList { get; set; }
        public SelectListView SelectList { get; set; }     
    }

    public enum TabPageType
    {
        eObject,
        eOpenTable,
        eNewTable,
        eDesignTable,
        eOpenView,
        eNewView,
        eDesignView,
        eOpenSelect,
        eNewSelect
    }

    public class TabPageTypeInfo
    {
        public TabPageTypeInfo(TabPageType type, object info)
        {
            this.PageType = type;
            this.Info = info;
        }
        public TabPageType PageType { get; set; }
        public object Info { get; set; }
        public OpenTablePage OpenTablePage { get; set; }
        public DesignTablePage DesignTablePage { get; set; }
        public OpenViewPage OpenViewPage { get; set; }
        public NewSelectPage NewSelectPage { get; set; }

    }

    public class MySyntaxHighlightServiceCSharp : ISyntaxHighlightService
    {
        readonly RichEditControl syntaxEditor;
        SyntaxColors syntaxColors;
        SyntaxHighlightProperties commentProperties;
        SyntaxHighlightProperties keywordProperties;
        SyntaxHighlightProperties stringProperties;
        SyntaxHighlightProperties xmlCommentProperties;
        SyntaxHighlightProperties textProperties;
        public MySyntaxHighlightServiceCSharp(RichEditControl syntaxEditor)
        {
            this.syntaxEditor = syntaxEditor;
            syntaxColors = new SyntaxColors(UserLookAndFeel.Default);
        }

        void HighlightSyntax(TokenCollection tokens)
        {
            commentProperties = new SyntaxHighlightProperties();
            commentProperties.ForeColor = syntaxColors.CommentColor;
            keywordProperties = new SyntaxHighlightProperties();
            keywordProperties.ForeColor = syntaxColors.KeywordColor;
            stringProperties = new SyntaxHighlightProperties();
            stringProperties.ForeColor = syntaxColors.StringColor;
            xmlCommentProperties = new SyntaxHighlightProperties();
            xmlCommentProperties.ForeColor = syntaxColors.XmlCommentColor;
            textProperties = new SyntaxHighlightProperties();
            textProperties.ForeColor = syntaxColors.TextColor;
            if (tokens == null || tokens.Count == 0)
                return;
            Document document = syntaxEditor.Document;
            //CharacterProperties cp = document.BeginUpdateCharacters(0, 1);
            List<SyntaxHighlightToken> syntaxTokens = new List<SyntaxHighlightToken>(tokens.Count);
            foreach (Token token in tokens)
            {
                HighlightCategorizedToken((CategorizedToken)token, syntaxTokens);
            }
            document.ApplySyntaxHighlight(syntaxTokens);
            //document.EndUpdateCharacters(cp);
        }

        void HighlightCategorizedToken(CategorizedToken token, List<SyntaxHighlightToken> syntaxTokens)
        {
            Color backColor = syntaxEditor.ActiveView.BackColor;
            TokenCategory category = token.Category;
            if (category == TokenCategory.Comment)
                syntaxTokens.Add(SetTokenColor(token, commentProperties, backColor));
            else if (category == TokenCategory.Keyword)
                syntaxTokens.Add(SetTokenColor(token, keywordProperties, backColor));
            else if (category == TokenCategory.String)
                syntaxTokens.Add(SetTokenColor(token, stringProperties, backColor));
            else if (category == TokenCategory.XmlComment)
                syntaxTokens.Add(SetTokenColor(token, xmlCommentProperties, backColor));
            else
                syntaxTokens.Add(SetTokenColor(token, textProperties, backColor));
        }

        SyntaxHighlightToken SetTokenColor(Token token, SyntaxHighlightProperties foreColor, Color backColor)
        {
            int paragraphStart = DocumentHelper.GetParagraphStart(syntaxEditor.Document.Paragraphs[token.Range.Start.Line - 1]);
            int tokenStart = paragraphStart + token.Range.Start.Offset - 1;
            if (token.Range.End.Line != token.Range.Start.Line)
                paragraphStart = DocumentHelper.GetParagraphStart(syntaxEditor.Document.Paragraphs[token.Range.End.Line - 1]);
            int tokenEnd = paragraphStart + token.Range.End.Offset - 1;
            Debug.Assert(tokenEnd > tokenStart);
            return new SyntaxHighlightToken(tokenStart, tokenEnd - tokenStart, foreColor);
        }

        #region #ISyntaxHighlightServiceMembers
        public void Execute()
        {
            string newText = syntaxEditor.Text;
            // Determine language by file extension.
            string ext = System.IO.Path.GetExtension(syntaxEditor.Options.DocumentSaveOptions.CurrentFileName);

            //ParserLanguageID lang_ID = ParserLanguage.FromFileExtension(ext);
            //// Do not parse HTML or XML.
            //if (lang_ID == ParserLanguageID.Html ||
            //    lang_ID == ParserLanguageID.Xml ||
            //    lang_ID == ParserLanguageID.None) return;
            ParserLanguageID lang_ID = ParserLanguageID.CSharp;
            // Use DevExpress.CodeParser to parse text into tokens.
            ITokenCategoryHelper tokenHelper = TokenCategoryHelperFactory.CreateHelper(lang_ID);
            TokenCollection highlightTokens;
            highlightTokens = tokenHelper.GetTokens(newText);
            HighlightSyntax(highlightTokens);
        }

        public void ForceExecute()
        {
            Execute();
        }
        #endregion #ISyntaxHighlightServiceMembers
    }

    public class SyntaxColors
    {
        static Color DefaultCommentColor { get { return Color.Green; } }
        static Color DefaultKeywordColor { get { return Color.Blue; } }
        static Color DefaultStringColor { get { return Color.Brown; } }
        static Color DefaultXmlCommentColor { get { return Color.Gray; } }
        static Color DefaultTextColor { get { return Color.Black; } }
        UserLookAndFeel lookAndFeel;
        public Color CommentColor { get { return GetCommonColorByName(CommonSkins.SkinInformationColor, DefaultCommentColor); } }
        public Color KeywordColor { get { return GetCommonColorByName(CommonSkins.SkinQuestionColor, DefaultKeywordColor); } }
        public Color TextColor { get { return GetCommonColorByName(CommonColors.WindowText, DefaultTextColor); } }
        public Color XmlCommentColor { get { return GetCommonColorByName(CommonColors.DisabledText, DefaultXmlCommentColor); } }
        public Color StringColor { get { return GetCommonColorByName(CommonSkins.SkinWarningColor, DefaultStringColor); } }
        public SyntaxColors(UserLookAndFeel lookAndFeel)
        {
            this.lookAndFeel = lookAndFeel;
        }

        Color GetCommonColorByName(string colorName, Color defaultColor)
        {
            Skin skin = CommonSkins.GetSkin(lookAndFeel);
            if (skin == null)
                return defaultColor;
            return skin.Colors[colorName];
        }
    }

    public class CustomSyntaxHighlightService : ISyntaxHighlightService
    {
        #region #parsetokens
        readonly Document document;
        SyntaxHighlightProperties defaultSettings = new SyntaxHighlightProperties() { ForeColor = Color.Black };
        SyntaxHighlightProperties keywordSettings = new SyntaxHighlightProperties() { ForeColor = Color.Blue };
        SyntaxHighlightProperties stringSettings = new SyntaxHighlightProperties() { ForeColor = Color.Green };
        string[] keywords = new string[] {
            "INSERT", "SELECT", "CREATE", "TABLE", "USE", "IDENTITY", "ON", "OFF", "NOT", "NULL", "WITH", "SET" };

        public CustomSyntaxHighlightService(Document document)
        {
            this.document = document;
        }

        private List<SyntaxHighlightToken> ParseTokens()
        {
            List<SyntaxHighlightToken> tokens = new List<SyntaxHighlightToken>();
            DocumentRange[] ranges = null;
            // search for quotation marks
            ranges = document.FindAll("'", SearchOptions.None);
            for (int i = 0; i < ranges.Length / 2; i++)
            {
                tokens.Add(new SyntaxHighlightToken(ranges[i * 2].Start.ToInt(),
                    ranges[i * 2 + 1].Start.ToInt() - ranges[i * 2].Start.ToInt() + 1, stringSettings));
            }

            // search for keywords
            for (int i = 0; i < keywords.Length; i++)
            {
                ranges = document.FindAll(keywords[i], SearchOptions.CaseSensitive | SearchOptions.WholeWord);
                for (int j = 0; j < ranges.Length; j++)
                {
                    if (!IsRangeInTokens(ranges[j], tokens))
                        tokens.Add(new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length, keywordSettings));
                }
            }
            // order tokens by their start position
            tokens.Sort(new SyntaxHighlightTokenComparer());
            // fill in gaps in document coverage
            AddPlainTextTokens(tokens);
            return tokens;
        }

        private void AddPlainTextTokens(List<SyntaxHighlightToken> tokens)
        {
            int count = tokens.Count;
            if (count == 0)
            {
                tokens.Add(new SyntaxHighlightToken(0, document.Range.End.ToInt(), defaultSettings));
                return;
            }
            tokens.Insert(0, new SyntaxHighlightToken(0, tokens[0].Start, defaultSettings));

            for (int i = 1; i < count; i++)
            {
                tokens.Insert(i * 2, new SyntaxHighlightToken(tokens[i * 2 - 1].End,
                tokens[i * 2].Start - tokens[i * 2 - 1].End, defaultSettings));
            }
            tokens.Add(new SyntaxHighlightToken(tokens[count * 2 - 1].End,
            document.Range.End.ToInt() - tokens[count * 2 - 1].End, defaultSettings));
        }

        private bool IsRangeInTokens(DocumentRange range, List<SyntaxHighlightToken> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (range.Start.ToInt() >= tokens[i].Start && range.End.ToInt() <= tokens[i].End)
                    return true;
            }
            return false;
        }
        
        #endregion #parsetokens
        #region #ISyntaxHighlightServiceMembers

        public void ForceExecute()
        {
            Execute();
        }

        public void Execute()
        {
            document.ApplySyntaxHighlight(ParseTokens());
        }
        #endregion #ISyntaxHighlightServiceMembers
    }
    
    #region #SyntaxHighlightTokenComparer
    public class SyntaxHighlightTokenComparer : IComparer<SyntaxHighlightToken>
    {
        public int Compare(SyntaxHighlightToken x, SyntaxHighlightToken y)
        {
            return x.Start - y.Start;
        }
    }
    #endregion #SyntaxHighlightTokenComparer

}