namespace Garlua.IDE.Scintilla
{
    partial class ScintillaControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.scintillaEditor1 = new Garlua.IDE.Scintilla.ScintillaEditor();
            ((System.ComponentModel.ISupportInitialize)(this.scintillaEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // scintillaEditor1
            // 
            this.scintillaEditor1.ConfigurationManager.CustomLocation = "ScintillaNET.xml";
            this.scintillaEditor1.ConfigurationManager.Language = "lua";
            this.scintillaEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintillaEditor1.FirstVisibleLine = 0;
            this.scintillaEditor1.Lexing.Lexer = ScintillaNET.Lexer.Lua;
            this.scintillaEditor1.Lexing.LexerName = "lua";
            this.scintillaEditor1.Lexing.LineCommentPrefix = "";
            this.scintillaEditor1.Lexing.StreamCommentPrefix = "";
            this.scintillaEditor1.Lexing.StreamCommentSufix = "";
            this.scintillaEditor1.Location = new System.Drawing.Point(0, 0);
            this.scintillaEditor1.Margins.Margin0.Width = 50;
            this.scintillaEditor1.Margins.Margin1.Width = 0;
            this.scintillaEditor1.Name = "scintillaEditor1";
            this.scintillaEditor1.Scrolling.HorizontalWidth = 50;
            this.scintillaEditor1.Size = new System.Drawing.Size(610, 397);
            this.scintillaEditor1.Styles.ControlChar.ForeColor = System.Drawing.Color.Black;
            this.scintillaEditor1.TabIndex = 0;
            // 
            // ScintillaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scintillaEditor1);
            this.Name = "ScintillaControl";
            this.Size = new System.Drawing.Size(610, 397);
            ((System.ComponentModel.ISupportInitialize)(this.scintillaEditor1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        public ScintillaEditor scintillaEditor1;

    }
}
