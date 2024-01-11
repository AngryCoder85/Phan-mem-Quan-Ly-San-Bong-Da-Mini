
namespace QLiSanBong_Solution.GUI
{
    partial class DoanhThuDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoanhThuDV));
            this.dataGrDThuDV = new System.Windows.Forms.DataGridView();
            this.btnDeleteDthuDV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrDThuDV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrDThuDV
            // 
            this.dataGrDThuDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrDThuDV.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGrDThuDV.Location = new System.Drawing.Point(0, 0);
            this.dataGrDThuDV.Name = "dataGrDThuDV";
            this.dataGrDThuDV.Size = new System.Drawing.Size(710, 436);
            this.dataGrDThuDV.TabIndex = 1;
            // 
            // btnDeleteDthuDV
            // 
            this.btnDeleteDthuDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDthuDV.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteDthuDV.Image")));
            this.btnDeleteDthuDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDthuDV.Location = new System.Drawing.Point(315, 442);
            this.btnDeleteDthuDV.Name = "btnDeleteDthuDV";
            this.btnDeleteDthuDV.Size = new System.Drawing.Size(76, 42);
            this.btnDeleteDthuDV.TabIndex = 2;
            this.btnDeleteDthuDV.Text = "Xoá";
            this.btnDeleteDthuDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteDthuDV.UseVisualStyleBackColor = true;
            // 
            // DoanhThuDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 496);
            this.Controls.Add(this.btnDeleteDthuDV);
            this.Controls.Add(this.dataGrDThuDV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DoanhThuDV";
            this.Text = "Doanh thu dịch vụ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrDThuDV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrDThuDV;
        private System.Windows.Forms.Button btnDeleteDthuDV;
    }
}