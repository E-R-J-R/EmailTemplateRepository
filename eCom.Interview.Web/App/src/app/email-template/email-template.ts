export interface IEmailTemplate {
    Guid: string;
    EmailLabel: string;
    FromAddress: string;
    Subject: string;
    TemplateText: string;
    EmailType: string;
    Active: boolean;
    DateUpdated: Date;
    LoadDrafts: boolean;
    ParentId: string;
    VersionCount: number;
    IsDefault: boolean;
    BccAddress: string;
    IsDraft: boolean;
    Versions: IEmailTemplate[];
}