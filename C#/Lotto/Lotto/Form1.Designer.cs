namespace Lotto
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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.Ball = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNum = new System.Windows.Forms.Label();
            this.lbBall = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.Ball});
            this.shapeContainer1.Size = new System.Drawing.Size(300, 262);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Lime;
            this.Ball.BorderColor = System.Drawing.Color.Lime;
            this.Ball.FillColor = System.Drawing.Color.Lime;
            this.Ball.FillGradientColor = System.Drawing.Color.Lime;
            this.Ball.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.Ball.Location = new System.Drawing.Point(87, 25);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(100, 100);
            this.Ball.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(213, 190);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(213, 227);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "뽑기";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "당첨번호";
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Font = new System.Drawing.Font("굴림", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbNum.Location = new System.Drawing.Point(12, 230);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(0, 20);
            this.lbNum.TabIndex = 4;
            // 
            // lbBall
            // 
            this.lbBall.AutoSize = true;
            this.lbBall.BackColor = System.Drawing.Color.Lime;
            this.lbBall.Font = new System.Drawing.Font("굴림", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbBall.Location = new System.Drawing.Point(111, 57);
            this.lbBall.Name = "lbBall";
            this.lbBall.Size = new System.Drawing.Size(35, 33);
            this.lbBall.TabIndex = 5;
            this.lbBall.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(300, 262);
            this.Controls.Add(this.lbBall);
            this.Controls.Add(this.lbNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lotto";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape Ball;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.Label lbBall;
    }
}

