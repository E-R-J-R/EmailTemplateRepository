import { IEmailTemplate } from './email-template';

export interface IEmailResponse {
    EmailTemplates: IEmailTemplate[];
    TotalRecordCount: number;
}