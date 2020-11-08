import { Component, OnInit } from '@angular/core';
import { IEmailTemplate } from './email-template'
import { ISearchParam } from '../shared/search-param'
import { EmailTemplateService } from '../email-template/email-template.service'
import { IEmailResponse } from './email-response';

@Component({
  selector: 'app-email-template',
  templateUrl: './email-template.component.html',
  styleUrls: ['./email-template.component.css']
})
export class EmailTemplateComponent implements OnInit {

  emailTemplates: IEmailTemplate[] = [];
  param: ISearchParam;
  totalRecordCount: number = 0;
  page: number = 1;
  pageSize: number = 10;
  orderBy: string = "EmailLabel";
  desc: boolean = false;
  searchLabel: string = "";
  searchAddress: string = "";

  constructor(private _emailTemplateService: EmailTemplateService) { }

  ngOnInit(): void {
    //On load parameters
    this.param = { page: this.page, pageSize: this.pageSize, searchField: "", searchText: "", orderBy: this.orderBy, desc: this.desc };
    this.loadGrid(this.param);
  }

  loadGrid(param: ISearchParam) {
    this._emailTemplateService.getPagedEmailTemplate(this.param).subscribe((data: IEmailResponse) => {
      this.emailTemplates = data.EmailTemplates;
      this.totalRecordCount = data.TotalRecordCount;
    });
  }

  onPageChange(page) {
    this.page = page;
    this.param.page = this.page;
    this.loadGrid(this.param);
  }

  sortField(columnName) {
    this.desc = columnName === this.orderBy ? !this.desc : false;
    this.param.desc = this.desc;
    this.orderBy = columnName;
    this.param.orderBy = this.orderBy;
    this.loadGrid(this.param);
  }

  onLabelBlur() {
    this.param.searchField = "EmailLabel";
    this.param.searchText = this.searchLabel;
    this.param.page = 1;
    this.param.orderBy = "";
    this.param.desc = false;
    this.loadGrid(this.param);
  }

  onAddressBlur() {
    this.param.searchField = "FromAddress";
    this.param.searchText = this.searchAddress;
    this.param.page = 1;
    this.param.orderBy = "";
    this.param.desc = false;
    this.loadGrid(this.param);
  }

}
