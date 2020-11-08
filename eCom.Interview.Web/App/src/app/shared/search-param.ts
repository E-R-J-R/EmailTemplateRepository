export interface ISearchParam {
    page: number;
    pageSize: number;
    searchField: string;
    searchText: string;
    orderBy: string;
    desc: boolean;
}