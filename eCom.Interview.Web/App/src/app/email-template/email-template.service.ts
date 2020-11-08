import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { IEmailTemplate } from './email-template'
import { IEmailResponse} from './email-response'
import { ISearchParam } from '../shared/search-param'

@Injectable({
  providedIn: 'root'
})
export class EmailTemplateService {

  private _server = 'https://localhost:44334/'
    private _getPagedEmailTemplateUrl = 'api/emailtemplate/getpaged';
    errorMessage: string;

  constructor(private _http: HttpClient) { }

  getPagedEmailTemplate(param: ISearchParam) : Observable<any> {

    const headers = { 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' };
    const body = { page: param.page, pageSize: param.pageSize, searchField: param.searchField, searchText: param.searchText, orderBy: param.orderBy, desc: param.desc };

    return this._http.post(this._server + this._getPagedEmailTemplateUrl, body, {headers});

  }
  
}
