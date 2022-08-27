namespace NesDebugger;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private DataGridView memory;
    private ListBox instructions;
    private CheckedListBox registers;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.memory = new System.Windows.Forms.DataGridView();
        this.instructions = new System.Windows.Forms.ListBox();
        this.registers = new System.Windows.Forms.CheckedListBox();
        ((System.ComponentModel.ISupportInitialize)(this.memory)).BeginInit();
        this.SuspendLayout();
        // 
        // memory
        // 
        this.memory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.memory.Location = new System.Drawing.Point(218, 307);
        this.memory.Name = "memory";
        this.memory.RowTemplate.Height = 25;
        this.memory.Size = new System.Drawing.Size(595, 192);
        this.memory.TabIndex = 0;
        for (var i = 0; i < 16; i += 1)
        {
            this.memory.Columns.Add($"{i:x}", $"{i:x}");
        }

        // Can't do this, this is inefficient.
        /*for (var i = 0; i < ushort.MaxValue; i += 1)
        {
            for (var y = 0; y < 15; y += 1)
            {
                this.memory.Rows[i].Cells[y].Value = memory[i];    
            }
            this.memory.Rows.Add();
        }*/

        // 
        // instructions
        // 
        this.instructions.FormattingEnabled = true;
        this.instructions.ItemHeight = 15;
        this.instructions.Location = new System.Drawing.Point(573, 12);
        this.instructions.Name = "instructions";
        this.instructions.Size = new System.Drawing.Size(240, 289);
        this.instructions.TabIndex = 1;
        // 
        // registers
        // 
        this.registers.FormattingEnabled = true;
        this.registers.Location = new System.Drawing.Point(12, 307);
        this.registers.Name = "registers";
        this.registers.Size = new System.Drawing.Size(192, 184);
        this.registers.TabIndex = 2;
        this.registers.Items.Add("Carry");
        this.registers.Items.Add("Zero Result");
        this.registers.Items.Add("Interrupt Disable");
        this.registers.Items.Add("Decimal Mode");
        this.registers.Items.Add("Break");
        this.registers.Items.Add("Overflow");
        this.registers.Items.Add("Negative Result");

        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(825, 511);
        this.Controls.Add(this.registers);
        this.Controls.Add(this.instructions);
        this.Controls.Add(this.memory);
        this.Name = "Form1";
        this.Text = "CpuDebugger";
        ((System.ComponentModel.ISupportInitialize)(this.memory)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion


}
