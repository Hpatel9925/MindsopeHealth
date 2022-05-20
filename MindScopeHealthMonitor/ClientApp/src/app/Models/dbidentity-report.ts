import { DbDetails } from "./db-details";
import { TableColumn } from "./table-column";

export class DBIdentityReport {
  strKey!: string;
  strValue!: string;
  listDBDetails!: Array<DbDetails>;
  listofTableColumn!: Array<TableColumn>;
}
