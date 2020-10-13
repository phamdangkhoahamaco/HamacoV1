using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;

namespace HAMACO
{
    public class MultiSelectionEditingHelper
    {
        public MultiSelectionEditingHelper(GridView view)
        {
            this.view = view;
            view.Appearance.FocusedCell.BackColor = view.PaintAppearance.SelectedRow.BackColor;
            view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            view.OptionsSelection.MultiSelect = true;
            view.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);

        

            this.view.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDownFocused;
            this.view.MouseUp += view_MouseUp;
            this.view.CellValueChanged += view_CellValueChanged;
            this.view.MouseDown += view_MouseDown;
            this.view.SelectionChanged += view_SelectionChanged;

        }

        private GridView view;


        void view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = 0;
            Double sum = 0;
            String str="";
            GridCell[] cells = view.GetSelectedCells();
         
            foreach (GridCell cell in cells)
            {
                str = "";
                if (view.GetRowCellValue(cell.RowHandle, cell.Column) != null)
                    str = view.GetRowCellValue(cell.RowHandle, cell.Column).ToString();
              
                
                if (p.IsNumeric(str))
                {
                    sum += Convert.ToDouble(str);
                }
                count += 1;
            }

        }
        void view_MouseDown(object sender, MouseEventArgs e)
        {
            if (GetInSelectedCell(e))
            {
                GridHitInfo hi = view.CalcHitInfo(e.Location);
                if (view.FocusedRowHandle == hi.RowHandle)
                {
                    view.FocusedColumn = hi.Column;
                    DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        void view_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            OnCellValueChanged(e);
        }

        bool lockEvents;
        GridColumn gcol;
        private void OnCellValueChanged(CellValueChangedEventArgs e)
        {
            gcol = e.Column;
            if (lockEvents)
                return;
            lockEvents = true;
            SetSelectedCellsValues(e.Value);
            lockEvents = false;
        }

        private void SetSelectedCellsValues(object value)
        {
            try
            {
                view.BeginUpdate();
                GridCell[] cells = view.GetSelectedCells();
                foreach (GridCell cell in cells)
                { 
                   if (gcol ==cell.Column)
                    view.SetRowCellValue(cell.RowHandle, cell.Column, value);
                }
            }
            catch (Exception ex) { }
            finally { view.EndUpdate(); }
        }

        private bool GetInSelectedCell(MouseEventArgs e)
        {
            GridHitInfo hi = view.CalcHitInfo(e.Location);
            return hi.InRowCell && view.IsCellSelected(hi.RowHandle, hi.Column);
        }

        void view_MouseUp(object sender, MouseEventArgs e)
        {
            bool inSelectedCell = GetInSelectedCell(e);
            if (inSelectedCell)
            {
                DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                view.ShowEditorByMouse();
            }
        }
    }
}
