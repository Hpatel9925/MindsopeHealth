import { Component, HostListener} from '@angular/core';
import { Database } from '../Models/database';
import { SharedserviceService } from '../services/sharedservice.service';
import { DbTable } from '../Models/db-table';
import { TableColumn } from '../Models/table-column';
import { DBIdentityReport } from '../Models/dbidentity-report';
import { ThemePalette } from '@angular/material/core';
import { FormGroup, FormArray, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-database',
  templateUrl: './database.component.html'
})
export class DatabaseComponent {

  DatabaseList: Database[] = [];
  tableList: DbTable[] = [];
  columnList: TableColumn[] = [];
  DBIdentityReportList: DBIdentityReport[] = [];
  selectedTable!: any;
  selectedDatabases!: Int32Array;
  selectedColumns!: any;
  isDatabaseSelected: boolean = false;
  isTableSelected: boolean = false;
  isColumnsSelected: boolean = false;
  isReportExists: boolean = false;
  dbId!: number;
  isToken!: boolean;
  form: FormGroup;
  TableColumns: FormGroup;
  FilterData: Array<any> = [
    { name: 'Unmatched Data', value: 1 },
    { name: 'All', value: 2 }
  ];
  
  constructor(private srv: SharedserviceService, private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      SelectedFilterID: []
    });

    this.TableColumns = this.formBuilder.group({
      Columns: this.formBuilder.array([])
    });
  }

  ngOnInit(): void {
    if (sessionStorage.getItem('Token') != null) {
      this.isToken = true;
      this.srv.getDatabases().subscribe((data: any) => {
      this.DatabaseList = data;
      });
    }    
  }

  getTableNames(e: any) {
    this.isDatabaseSelected = true;
    this.dbId = parseInt(e.target.value);
    this.srv.postDatabaseId(this.dbId).subscribe((result: any) => {
    this.tableList = result;
    });
  }

  getColumns(e: any) {
    this.isTableSelected = true;
    this.selectedTable = e.target.value;

    this.srv.getColumnList(this.selectedTable, this.dbId).subscribe((result: any) => {
      this.columnList = result;
    });
  }
  //-------------------------------------------------------------------------------------------------
  onCheckBoxChange(name: string, isChecked: boolean) {
    
    let Columns: FormArray = this.TableColumns.get('Columns') as FormArray;
    if (isChecked) {
      Columns.push(new FormControl(name));
    }
    else {
      let i: number = 0;
      Columns.controls.forEach((item: FormControl) => {
        if (item.value == name) {
          Columns.removeAt(i);
          return;
        }
        i++;
      });
    }
    
  }

  onSubmit() {
    
    let Columns: FormArray = this.TableColumns.get('Columns') as FormArray;
    this.isColumnsSelected = true
    this.selectedColumns = Columns.value;
    Columns.clear()
    this.srv.postDBIdentityReport(this.selectedColumns, this.selectedTable, this.dbId).subscribe((result: any) => {
      this.DBIdentityReportList = result;
      this.isReportExists = true
    });
  }

  //-----------------------------------------------------------------------------------------------------------
  ExportReport() {
    this.srv.postExportReport(this.DBIdentityReportList).subscribe((result: any) => {
      alert("Report Successfully save in your 'D' Drive..");
    });
  }
  //------------------------------------------------------------------------------------------------------
  onRadioButtonChange(e) {
    const selectedFilterID: FormArray = this.form.get('filterData') as FormArray;

    if (e.target.checked) {
      selectedFilterID.push(new FormControl(e.target.value));
    }
    else
    {
      const index = selectedFilterID.controls.findIndex(x => x.value === e.target.value);
      selectedFilterID.removeAt(index);
    }
  }

  onFilterData() {
    const SelectedFilter = this.form.value.SelectedFilterID;
    this.srv.postFilterDataDBIdentityReport(this.selectedColumns, this.selectedTable, this.dbId, SelectedFilter).subscribe((result: any) => {
      this.DBIdentityReportList = result;
    });
  }
  //-------------------------------------------------------------------------------------------------------------------------
}
