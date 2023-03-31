import { TableName } from "./tableName";

export class Category {
    constructor(
        public categoryId: number,
        public categoryName: string,
    ) { }

    public static nameList: TableName[] = [
        new TableName(1, "ID"),
        new TableName(2, "Name"),
    ]


    public static get List(): TableName[] {
        return Category.nameList;
    }
}