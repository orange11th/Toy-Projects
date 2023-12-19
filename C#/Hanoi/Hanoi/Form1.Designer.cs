namespace Hanoi
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.recTray5 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.recTray3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.recTray4 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.recTray0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.recTray2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.recTray1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.recFlag3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.recFlag2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.recFlag1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel1.Controls.Add(this.shapeContainer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer1.Panel2.Controls.Add(this.btnNext);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrev);
            this.splitContainer1.Panel2.Controls.Add(this.btnReset);
            this.splitContainer1.Size = new System.Drawing.Size(591, 370);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 0;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.recTray5,
            this.recTray3,
            this.recTray4,
            this.recTray0,
            this.recTray2,
            this.recTray1,
            this.recFlag3,
            this.recFlag2,
            this.recFlag1});
            this.shapeContainer1.Size = new System.Drawing.Size(591, 315);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // recTray5
            // 
            this.recTray5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.recTray5.Cursor = System.Windows.Forms.Cursors.Default;
            this.recTray5.FillColor = System.Drawing.Color.Purple;
            this.recTray5.FillGradientColor = System.Drawing.Color.Yellow;
            this.recTray5.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.recTray5.Location = new System.Drawing.Point(443, 20);
            this.recTray5.Name = "recTray5";
            this.recTray5.Size = new System.Drawing.Size(130, 15);
            // 
            // recTray3
            // 
            this.recTray3.FillColor = System.Drawing.Color.Green;
            this.recTray3.FillGradientColor = System.Drawing.Color.Yellow;
            this.recTray3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.recTray3.Location = new System.Drawing.Point(220, 22);
            this.recTray3.Name = "recTray3";
            this.recTray3.Size = new System.Drawing.Size(90, 15);
            // 
            // recTray4
            // 
            this.recTray4.FillColor = System.Drawing.Color.Blue;
            this.recTray4.FillGradientColor = System.Drawing.Color.Yellow;
            this.recTray4.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.recTray4.Location = new System.Drawing.Point(322, 21);
            this.recTray4.Name = "recTray4";
            this.recTray4.Size = new System.Drawing.Size(110, 15);
            // 
            // recTray0
            // 
            this.recTray0.FillColor = System.Drawing.Color.Red;
            this.recTray0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.recTray0.Location = new System.Drawing.Point(9, 22);
            this.recTray0.Name = "recTray0";
            this.recTray0.Size = new System.Drawing.Size(30, 15);
            // 
            // recTray2
            // 
            this.recTray2.FillColor = System.Drawing.Color.Yellow;
            this.recTray2.FillGradientColor = System.Drawing.Color.Yellow;
            this.recTray2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.recTray2.Location = new System.Drawing.Point(129, 22);
            this.recTray2.Name = "recTray2";
            this.recTray2.Size = new System.Drawing.Size(70, 15);
            // 
            // recTray1
            // 
            this.recTray1.FillColor = System.Drawing.Color.Orange;
            this.recTray1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.recTray1.Location = new System.Drawing.Point(61, 20);
            this.recTray1.Name = "recTray1";
            this.recTray1.Size = new System.Drawing.Size(50, 15);
            // 
            // recFlag3
            // 
            this.recFlag3.Location = new System.Drawing.Point(482, 94);
            this.recFlag3.Name = "recFlag3";
            this.recFlag3.Size = new System.Drawing.Size(10, 242);
            // 
            // recFlag2
            // 
            this.recFlag2.Location = new System.Drawing.Point(291, 94);
            this.recFlag2.Name = "recFlag2";
            this.recFlag2.Size = new System.Drawing.Size(10, 242);
            // 
            // recFlag1
            // 
            this.recFlag1.Location = new System.Drawing.Point(100, 94);
            this.recFlag1.Name = "recFlag1";
            this.recFlag1.Size = new System.Drawing.Size(10, 242);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(499, 16);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(391, 16);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(36, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 370);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hanoi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recFlag3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recFlag2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recFlag1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recTray1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recTray0;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recTray2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recTray5;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recTray3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recTray4;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnReset;

    }
}

