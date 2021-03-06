﻿namespace ITLec.EmailTemplateManager.Forms
{
    partial class EmailTemplateEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDeleteEmailTemplate = new System.Windows.Forms.Button();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.btnUpdatePublish = new System.Windows.Forms.Button();
            this.btnlVisualEditor = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblDataDescription = new System.Windows.Forms.Label();
            this.tecDataDescription = new ICSharpCode.TextEditor.TextEditorControl();
            this.lblVisualizationDescription = new System.Windows.Forms.Label();
            this.tecVisualizationDescription = new ICSharpCode.TextEditor.TextEditorControl();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailTemplateType = new System.Windows.Forms.TextBox();
            this.btnOpenCRMEditor = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(940, 56);
            this.pnlTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "EmailTemplate Editor";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOpenCRMEditor);
            this.panel2.Controls.Add(this.buttonDeleteEmailTemplate);
            this.panel2.Controls.Add(this.buttonSaveAs);
            this.panel2.Controls.Add(this.btnUpdatePublish);
            this.panel2.Controls.Add(this.btnlVisualEditor);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 632);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 41);
            this.panel2.TabIndex = 1;
            // 
            // buttonDeleteEmailTemplate
            // 
            this.buttonDeleteEmailTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteEmailTemplate.Location = new System.Drawing.Point(576, 4);
            this.buttonDeleteEmailTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteEmailTemplate.Name = "buttonDeleteEmailTemplate";
            this.buttonDeleteEmailTemplate.Size = new System.Drawing.Size(128, 28);
            this.buttonDeleteEmailTemplate.TabIndex = 10;
            this.buttonDeleteEmailTemplate.Text = "Delete EmailTemplate";
            this.buttonDeleteEmailTemplate.UseVisualStyleBackColor = true;
            this.buttonDeleteEmailTemplate.Visible = false;
            this.buttonDeleteEmailTemplate.Click += new System.EventHandler(this.buttonDeleteEmailTemplate_Click);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveAs.Location = new System.Drawing.Point(704, 4);
            this.buttonSaveAs.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(128, 28);
            this.buttonSaveAs.TabIndex = 9;
            this.buttonSaveAs.Text = "Save As";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Visible = false;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // btnUpdatePublish
            // 
            this.btnUpdatePublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePublish.Location = new System.Drawing.Point(448, 4);
            this.btnUpdatePublish.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdatePublish.Name = "btnUpdatePublish";
            this.btnUpdatePublish.Size = new System.Drawing.Size(128, 28);
            this.btnUpdatePublish.TabIndex = 8;
            this.btnUpdatePublish.Text = "Update && Publish";
            this.btnUpdatePublish.UseVisualStyleBackColor = true;
            this.btnUpdatePublish.Visible = false;
            this.btnUpdatePublish.Click += new System.EventHandler(this.btnUpdatePublish_Click);
            // 
            // btnlVisualEditor
            // 
            this.btnlVisualEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlVisualEditor.Location = new System.Drawing.Point(216, 4);
            this.btnlVisualEditor.Margin = new System.Windows.Forms.Padding(4);
            this.btnlVisualEditor.Name = "btnlVisualEditor";
            this.btnlVisualEditor.Size = new System.Drawing.Size(135, 28);
            this.btnlVisualEditor.TabIndex = 7;
            this.btnlVisualEditor.Text = "Open Visual Editor";
            this.btnlVisualEditor.UseVisualStyleBackColor = true;
            this.btnlVisualEditor.Visible = false;
            this.btnlVisualEditor.Click += new System.EventHandler(this.btnlVisualEditor_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(352, 4);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(834, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(141, 62);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(789, 22);
            this.txtName.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(141, 110);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(789, 22);
            this.txtDescription.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 64);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 17);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Title";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(11, 113);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(79, 17);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "Description";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 136);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblDataDescription);
            this.splitContainer1.Panel1.Controls.Add(this.tecDataDescription);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblVisualizationDescription);
            this.splitContainer1.Panel2.Controls.Add(this.tecVisualizationDescription);
            this.splitContainer1.Size = new System.Drawing.Size(940, 491);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 6;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // lblDataDescription
            // 
            this.lblDataDescription.AutoSize = true;
            this.lblDataDescription.Location = new System.Drawing.Point(11, 0);
            this.lblDataDescription.Name = "lblDataDescription";
            this.lblDataDescription.Size = new System.Drawing.Size(55, 17);
            this.lblDataDescription.TabIndex = 6;
            this.lblDataDescription.Text = "Subject";
            // 
            // tecDataDescription
            // 
            this.tecDataDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tecDataDescription.IsReadOnly = false;
            this.tecDataDescription.Location = new System.Drawing.Point(141, 2);
            this.tecDataDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tecDataDescription.Name = "tecDataDescription";
            this.tecDataDescription.Size = new System.Drawing.Size(788, 126);
            this.tecDataDescription.TabIndex = 0;
            // 
            // lblVisualizationDescription
            // 
            this.lblVisualizationDescription.AutoSize = true;
            this.lblVisualizationDescription.Location = new System.Drawing.Point(11, 7);
            this.lblVisualizationDescription.Name = "lblVisualizationDescription";
            this.lblVisualizationDescription.Size = new System.Drawing.Size(40, 17);
            this.lblVisualizationDescription.TabIndex = 8;
            this.lblVisualizationDescription.Text = "Body";
            // 
            // tecVisualizationDescription
            // 
            this.tecVisualizationDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tecVisualizationDescription.IsReadOnly = false;
            this.tecVisualizationDescription.Location = new System.Drawing.Point(141, -1);
            this.tecVisualizationDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tecVisualizationDescription.Name = "tecVisualizationDescription";
            this.tecVisualizationDescription.Size = new System.Drawing.Size(788, 364);
            this.tecVisualizationDescription.TabIndex = 7;
            this.tecVisualizationDescription.Load += new System.EventHandler(this.tecVisualizationDescription_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Is Personal";
            // 
            // txtEmailTemplateType
            // 
            this.txtEmailTemplateType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailTemplateType.Enabled = false;
            this.txtEmailTemplateType.Location = new System.Drawing.Point(141, 86);
            this.txtEmailTemplateType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmailTemplateType.Name = "txtEmailTemplateType";
            this.txtEmailTemplateType.Size = new System.Drawing.Size(789, 22);
            this.txtEmailTemplateType.TabIndex = 7;
            // 
            // btnOpenCRMEditor
            // 
            this.btnOpenCRMEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenCRMEditor.Location = new System.Drawing.Point(88, 4);
            this.btnOpenCRMEditor.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenCRMEditor.Name = "btnOpenCRMEditor";
            this.btnOpenCRMEditor.Size = new System.Drawing.Size(127, 28);
            this.btnOpenCRMEditor.TabIndex = 11;
            this.btnOpenCRMEditor.Text = "Open CRM Editor";
            this.btnOpenCRMEditor.UseVisualStyleBackColor = true;
            this.btnOpenCRMEditor.Visible = false;
            this.btnOpenCRMEditor.Click += new System.EventHandler(this.btnOpenCRMEditor_Click);
            // 
            // EmailTemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 673);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmailTemplateType);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EmailTemplateEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EmailTemplate Editor";
            this.Load += new System.EventHandler(this.EmailTemplateEditor_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private ICSharpCode.TextEditor.TextEditorControl tecDataDescription;
        private System.Windows.Forms.Label lblDataDescription;
        private System.Windows.Forms.Label lblVisualizationDescription;
        private ICSharpCode.TextEditor.TextEditorControl tecVisualizationDescription;
        private System.Windows.Forms.Button btnlVisualEditor;
        private System.Windows.Forms.Button btnUpdatePublish;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonDeleteEmailTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailTemplateType;
        private System.Windows.Forms.Button btnOpenCRMEditor;
    }
}