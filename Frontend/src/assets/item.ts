import { TableName } from "./tableName";

export class Item{

    constructor(
        public id: number,
        public name: string,
        public location: string,
        public category: number,
        public status: number,
    ){}

    public static nameList: TableName[] = [new TableName(1, "ID"),new TableName(2, "Name"), new TableName(3, "Category"), new TableName(4, "Location"), new TableName(5, "Status")];


  public static get List(): TableName[] {
    return Item.nameList;
  }

}