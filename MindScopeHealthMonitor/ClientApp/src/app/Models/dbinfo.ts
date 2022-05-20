import { TableColumn } from "./table-column";

export class DBInfo {
  DBID!: number;
  tableName!: string;
  tableColumns!: Array<string>;
}
