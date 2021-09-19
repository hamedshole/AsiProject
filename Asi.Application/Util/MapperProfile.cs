using Asi.Domain.Entities;
using Asi.Domain.ValueObjects;
using Asi.Model;
using Asi.Model.ValueObjects;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Company = Asi.Model.ValueObjects.Company;

namespace Asi.Application.Util
{
    internal class MapperProfile : Profile
    {

        #region Converter Methods
        private string GetControlTime(int controltime)
        {
            string controlTimeText = string.Empty;
            switch (controltime)
            {
                case 1:
                    controlTimeText = "بازرسی اول";
                    break;
                case 2:
                    controlTimeText = "بازرسی دوم";
                    break;
                case 3:
                    controlTimeText = "بازرسی سوم";
                    break;
                case 4:
                    controlTimeText = "بازرسی چهارم";
                    break;
            }
            return controlTimeText;

        }
        private int GetControlRepeatTime(string repeatText)
        {
            int repeat = 0;

            if (repeatText == "بازرسی اول")
                repeat = 1;

            else if (repeatText == "بازرسی دوم")
                repeat = 2;

            else if (repeatText == "بازرسی سوم")
                repeat = 3;
            else if (repeatText == "بازرسی چهارم")
                repeat = 4;
            return repeat;
        }
        #endregion

        public MapperProfile()
        {

            CreateMap<ControlLink, Link>().ForMember(d=>d.Signiture,opt=>opt.MapFrom(m=>StaticMethods.SaveImage(m.Signiture,StaticMethods.SavedImageFormat.PNG,StaticMethods.ImageDirectory.Signitures)));
            CreateMap<Link, ControlLink>().ForMember(d => d.Signiture, opt => opt.MapFrom(m => StaticMethods.LoadImage(m.Signiture)));

            CreateMap<ControlLocation, Domain.ValueObjects.Location>();
            CreateMap<string, ControlImage>().ForMember(d => d.Path, opt => opt.MapFrom(m => StaticMethods.SaveImage(m, StaticMethods.SavedImageFormat.JPG, StaticMethods.ImageDirectory.Images))).ReverseMap();
            CreateMap<RequestCertificateControlModel, CertificateControl>()
                .ForMember(m => m.Images, opt => opt.MapFrom(m => m.ItemImage))
                .ForMember(m=>m.ControlDate,opt=>opt.MapFrom(m=>m.Time));

            CreateMap<Company, Asi.Model.ValueObjects.Company>().ReverseMap();
            CreateMap<CertificateControlModel, CertificateControl>();


            #region person

            CreateMap<Person, PersonModel>().ReverseMap();

            #endregion

            #region user

            CreateMap<UserModel, User>().
                ForMember(dto => dto.Role, opt => opt.Ignore());
            CreateMap<User, UserModel>().ForMember(model => model.Name, opt => opt.MapFrom(dto => dto.Person.Fullname)).
                ForMember(model => model.PhoneNumber, opt => opt.MapFrom(dto => dto.Person.PhoneNumber)).
                ForMember(model => model.Role, opt => opt.MapFrom(dto => dto.Role.Title));
            #endregion

            #region userrole

            CreateMap<UserRole, UserRoleModel>().ReverseMap();

            #endregion

            #region standardrefference


            #endregion

            #region formtemplate to dto
            CreateMap<FormTemplateModel, FormTemplate>()
                .ForMember(d => d.StandradRefference, opt => opt.MapFrom(m => m.StandardRefference))
                .ForMember(d => d.CertificateType, opt => opt.Ignore())
                .ForMember(d => d.CertificateTypeId, opt => opt.MapFrom(m => m.CertificateTypeId))
                .ForMember(m => m.Groups, opt => opt.MapFrom(m => m.Groups)).AfterMap((x, y) =>
                  {
                      for (int i = 0; i < y.Groups.Count; i++)
                      {
                          y.Groups.ElementAt(i).Order = i;
                      }
                  });
            CreateMap<FormTemplate, FormTemplateModel>()
                .ForMember(m => m.Groups, opt => opt.MapFrom(d => d.Groups));
            CreateMap<FormTemplateGroup, FormTemplateGroupModel>()
                .ForMember(m => m.AnswerColumns, opt => opt.MapFrom(d => d.AnswerColumns.Select(x => x.Title)))
                .ForMember(m => m.QuestionHeaders, opt => opt.MapFrom(d => d.QuestionHeaders.Select(x => x.Title)));
            CreateMap<FormTemplateRow, FormTemplateRowModel>().ForMember(x => x.MissMatchWords, opt => opt.MapFrom(d => d.MissMatchWords.Select(x => x.Text)));


            CreateMap<FormTemplateRowModel, FormTemplateRow>().ForMember(d => d.MissMatchWords, opt => opt.MapFrom(m => m.MissMatchWords));
            CreateMap<string, FormTemplateRowMissMatchWord>().ForMember(x => x.Text, opt => opt.MapFrom(m => m));
            CreateMap<FormTemplateGroupModel, FormTemplateGroup>()
                .ForMember(m => m.AnswerColumns, opt => opt.MapFrom(m => m.AnswerColumns))
                .ForMember(m => m.QuestionHeaders, opt => opt.MapFrom(m => m.QuestionHeaders))
                .ForMember(m => m.Questions, opt => opt.MapFrom(m => m.Questions)).AfterMap((x, y) =>
              {
                  for (int i = 0; i < y.Questions.Count; i++)
                  {
                      y.Questions.ElementAt(i).Order = i;
                  }
                  for (int i = 0; i < y.QuestionHeaders.Count; i++)
                  {
                      y.QuestionHeaders.ElementAt(i).Order = i;
                  }
                  for (int i = 0; i < y.AnswerColumns.Count; i++)
                  {
                      y.AnswerColumns.ElementAt(i).Order = i;
                  }
              });

            CreateMap<string, FormTemplateAnswerColumn>().ForMember(dto => dto.Title, opt => opt.MapFrom(x => x));
            CreateMap<string, FormTemplateQuestionHeader>().ForMember(dto => dto.Title, opt => opt.MapFrom(x => x));
            #endregion

            #region item
            CreateMap<Item, ItemModel>().ForMember(model => model.ServiceType, opt => opt.MapFrom(dto => dto.ServiceType.Title));
            CreateMap<ItemModel, Item>()
                .ForMember(m => m.Formtemplates, opt => opt.MapFrom(m => m.FormTemplates));
            #endregion

            #region department

            CreateMap<Department, DepartmentModel>();
            CreateMap<DepartmentModel, Department>();
            #endregion



            #region formtemplate to model
            CreateMap<FormTemplateAnswerColumn, string>().ConvertUsing(x => x.Title);
            CreateMap<FormTemplateQuestionHeader, string>().ConvertUsing(x => x.Title);
            CreateMap<FormTemplateRow, FormDataRowModel>().
                ForMember(m => m.MissMatchWords, opt => opt.MapFrom(d => d.MissMatchWords.Select(x => x.Text))).
                ForMember(m => m.TemplateId, opt => opt.MapFrom(dto => dto.Id)).
                ForMember(m => m.Id, opt => opt.Ignore()).ReverseMap();
            CreateMap<FormTemplate, FormDataModel>().
                ForMember(m => m.StandardRefference, opt => opt.MapFrom(d => d.StandradRefference))
                .ForMember(m => m.CertificateType, opt => opt.MapFrom(d => d.CertificateType.Title))
               .ForMember(model => model.TemplateId, opt => opt.MapFrom(dto => dto.Id)).
               ForMember(model => model.Groups, opt => opt.MapFrom(dto => dto.Groups));
            CreateMap<FormTemplateGroup, FormTemplateGroupModel>().
                ForMember(dto => dto.AnswerColumns, opt => opt.MapFrom(m => m.AnswerColumns)).
                ForMember(dto => dto.QuestionHeaders, opt => opt.MapFrom(m => m.QuestionHeaders));
            CreateMap<FormTemplateGroup, FormDataGroupModel>().ForMember(m => m.TemplateId, opt => opt.MapFrom(d => d.Id));
            #endregion

            #region formtemplate to data

            CreateMap<FormDataGroupModel, FormDataGroup>().
                ForMember(d => d.TemplateId, opt => opt.MapFrom(m => m.TemplateId)).
                ForMember(dto => dto.Id, opt => opt.MapFrom(m => 0)).ForMember(dto => dto.Answers, opt => opt.MapFrom(model => model.Questions)).
                ForMember(dto => dto.Description, opt => opt.MapFrom(model => model.Description)).ForMember(dto => dto.TemplateId, opt => opt.MapFrom(model => model.TemplateId)).
                ForMember(dto => dto.Id, opt => opt.Ignore()).AfterMap((x, y) =>
                {
                    for (int i = 0; i < y.Answers.Count; i++)
                    {
                        y.Answers.ElementAt(i).Order = i;
                    }
                });

            #endregion


            #region formdata to dto

            CreateMap<RequestCertificateModel, CertificateControl>().
               ForMember(dto => dto.Id, opt => opt.MapFrom(m => 0)).
               ForMember(dto => dto.MainControllerId, opt => opt.MapFrom(model => model.MainControllerId)).
               ForMember(dto => dto.CertificateControllerId, opt => opt.MapFrom(model => model.MainControllerId));
            // ForMember(dto => dto.ControlFormId, opt => opt.MapFrom(model => model.FormData.TemplateId)).
            //ForMember(dto => dto.ControlFormId, opt => opt.MapFrom(model => model.FormData.Id));

            CreateMap<RequestCertificateModel, Certificate>()
                .ForMember(d => d.Image, opt => opt.MapFrom(m => StaticMethods.SaveImage(m.Image, StaticMethods.SavedImageFormat.JPG, StaticMethods.ImageDirectory.Images)))
                .ForMember(d => d.Controls, opt => opt.MapFrom(m => m.FormDatas))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(m => 0))
                .ForMember(dto => dto.ProvinceIdId, opt => opt.MapFrom(model => model.ProvinenceId));


            CreateMap<FormDataModel, SavedFormData>().
                ForMember(dto => dto.Id, opt => opt.MapFrom(m => 0)).ForMember(dto => dto.TemplateId, opt => opt.MapFrom(m => m.TemplateId)).
                ForMember(dto => dto.Groups, opt => opt.MapFrom(m => m.Groups)).AfterMap((x, y) =>
                {
                    for (int i = 0; i < y.Groups.Count; i++)
                    {
                        y.Groups.ElementAt(i).Order = i;
                    }
                });
            //CreateMap<FormDataGroupModel, FormDataGroup>().
            // ForMember(dto => dto.Id, opt => opt.MapFrom(m => 0)).
            // ForMember(dto => dto.Answers, opt => opt.MapFrom(m => m.Questions)).
            // ForMember(dto => dto.Description, opt => opt.MapFrom(m => m.Description)).
            // ForMember(dto => dto.TemplateId, opt => opt.MapFrom(m => m.Id))
            // .AfterMap((x, y) =>
            // {
            //     for (int i = 0; i < y.Answers.Count; i++)
            //     {
            //         y.Answers.ElementAt(i).SetOrder(i);
            //     }
            // });

            CreateMap<FormDataRowModel, FormDataRow>().ForMember(x => x.MissMatchWord, opt => opt.MapFrom(m => m.SelectedMissMatchWord))
                .ForMember(d => d.GroupId, opt => opt.MapFrom(m => m.GroupId))
                .ForMember(d => d.TemplateId, opt => opt.MapFrom(m => m.TemplateId));

            #endregion

            #region certificateType 
            CreateMap<CertificateType, CertificateTypeModel>().ReverseMap();
            #endregion

            #region province
            CreateMap<Province, ProvinceModel>().ReverseMap();
            #endregion


            #region submitCertificate in dto


            CreateMap<CertificateModel, Certificate>().
                ForMember(m => m.Department, opt => opt.Ignore()).
                ForMember(m => m.ServiceType, opt => opt.Ignore()).
                ForMember(m => m.CertificateType, opt => opt.Ignore()).
                ForMember(m => m.Department, opt => opt.Ignore()).
                ForMember(m => m.Image, opt => opt.Ignore()).
                ForMember(m => m.Province, opt => opt.Ignore()).
                ForMember(m => m.Item, opt => opt.Ignore()).
                ForMember(m => m.RefferenceForm, opt => opt.Ignore()).
                ForMember(dto => dto.ProvinceIdId, opt => opt.MapFrom(model => model.ProvinceId)).ForMember(dto => dto.Controls, opt => opt.MapFrom(m => m.Controls));
            CreateMap<CertificateControlModel, CertificateControl>().
                ForMember(dto => dto.ControlFormId, opt => opt.MapFrom(m => m.ControlFormId)).
                ForMember(dto => dto.ControlTime, opt => opt.MapFrom(m => this.GetControlRepeatTime(m.ControlTime)))
                .ForMember(dto => dto.ControlDate, opt => opt.MapFrom(m => m.Time));

            #endregion


            #region formdata to model

            CreateMap<FormDataRow, FormDataRowModel>().
                ForMember(m => m.FirstQuestion, opt => opt.MapFrom(d => d.Template.FirstQuestion)).
                ForMember(m => m.SecondQuestion, opt => opt.MapFrom(d => d.Template.SecondQuestion)).
                ForMember(m => m.ThirdQuestion, opt => opt.MapFrom(d => d.Template.ThirdQuestion)).
                ForMember(m => m.ForthQuestion, opt => opt.MapFrom(d => d.Template.ForthQuestion));
            CreateMap<FormDataGroup, FormDataGroupModel>().
                ForMember(m => m.TemplateId, opt => opt.MapFrom(d => d.TemplateId)).
              ForMember(m => m.AnswerColumns, opt => opt.MapFrom(d => d.Template.AnswerColumns)).
              ForMember(m => m.Questions, opt => opt.MapFrom(d => d.Answers)).
              ForMember(m => m.Subtitle, opt => opt.MapFrom(d => d.Template.Subtitle)).
              ForMember(m => m.Title, opt => opt.MapFrom(d => d.Template.Title)).
              ForMember(m => m.IsCheckBox, opt => opt.MapFrom(d => d.Template.IsCheckbox)).
              ForMember(m => m.HasSubtitle, opt => opt.MapFrom(d => d.Template.HasSubtitle)).
              ForMember(m => m.QuestionHeaders, opt => opt.MapFrom(d => d.Template.QuestionHeaders));

            #endregion

            #region certificate to model

            CreateMap<Certificate, CertificateModel>()
                .ForMember(m => m.CertificateType, opt => opt.MapFrom(d => d.CertificateType.Title))
                .ForMember(m => m.Controls, opt => opt.Ignore())
                .ForMember(m => m.Department, opt => opt.MapFrom(d => d.Department.Title))
                .ForMember(m => m.ServiceType, opt => opt.MapFrom(d => d.ServiceType.Title))
                .ForMember(m => m.Item, opt => opt.MapFrom(d => d.Item.Title))
                .ForMember(m => m.Province, opt => opt.MapFrom(d => d.Province.Title));

            #endregion

            #region certificate control to model

            CreateMap<CertificateControl, CertificateControlModel>().
                ForMember(m => m.AgancyName, opt => opt.MapFrom(d => d.Agancy.Fullname)).
                 ForMember(m => m.AgancyName, opt => opt.AllowNull()).
                ForMember(m => m.BranchName, opt => opt.MapFrom(d => d.BranchPerson.Fullname)).
                ForMember(m => m.BranchName, opt => opt.AllowNull()).
                ForMember(m => m.CertificateControllerName, opt => opt.MapFrom(d => d.CertificateController.Fullname)).
                ForMember(m => m.CertificateControllerName, opt => opt.AllowNull()).
                ForMember(m => m.MainControllerName, opt => opt.MapFrom(d => d.MainController.Fullname)).
                ForMember(m => m.MarketingName, opt => opt.MapFrom(d => d.Marketing.Fullname)).
                ForMember(m => m.MarketingName, opt => opt.AllowNull()).
                ForMember(m => m.TechnicalManagerName, opt => opt.MapFrom(d => d.TechnicalManager.Fullname)).
                ForMember(m => m.TechnicalManagerName, opt => opt.AllowNull()).
                ForMember(m => m.Location, opt => opt.MapFrom(d => d.Location)).
                ForMember(m => m.Link, opt => opt.MapFrom(d => d.Link)).
                ForMember(m => m.Link, opt => opt.AllowNull()).
                ForMember(m => m.ControlTime, opt => opt.MapFrom(d => this.GetControlTime(d.ControlTime)));

            CreateMap<Location, ControlLocation>().ReverseMap();
            CreateMap<Link, ControlLink>().ReverseMap();


            #endregion

            #region payment to model
            CreateMap<Payment, PaymentModel>().ReverseMap();

            #endregion
            #region reportmodels

            CreateMap<CertificateControl, ControlReport>().ForMember(m => m.LinkName, opt => opt.MapFrom(d => d.Link.Fullname))
                .ForMember(m => m.LinkSigniture, opt => opt.MapFrom(d =>StaticMethods.LoadImage( d.Link.Signiture)))
                .ForMember(m => m.Time, opt => opt.MapFrom(d=>DateTime.Now));
            // .ForMember(m => m.Time, opt => opt.MapFrom(d => d.ControlDate));
            CreateMap<Certificate, CertificateReportModel>().ForMember(m => m.ControllerSigniture, opt => opt.MapFrom(d => StaticMethods.LoadImage(d.Controls.ElementAt(0).MainController.Signiture)))
                .ForMember(m => m.Controls, opt => opt.MapFrom(d => d.Controls)).
                ForMember(m => m.ControlDate, opt => opt.MapFrom(d => DateTime.Now)).
                // ForMember(m => m.ControlDate, opt => opt.MapFrom(d => d.Controls.ElementAt(0).ControlDate)).
                ForMember(x => x.EmployerAddress, opt => opt.MapFrom(cert => cert.Company.Address)).
                ForMember(x => x.EmployerName, opt => opt.MapFrom(cert => cert.Company.PhoneNumber)).
                ForMember(x => x.FileNumber, opt => opt.MapFrom(cert => string.Format("RS={0}", cert.Controls.ElementAt(0).ControlFormId.ToString()))).
                ForMember(x => x.ReviewDate, opt => opt.MapFrom(cert => cert.RefferenceForm.Template.ReviewDate)).
                ForMember(x => x.Groups, opt => opt.MapFrom(cert => cert.RefferenceForm.Groups));
            CreateMap<Certificate, ControlFormReportModel>()
               //.ForMember(m => m.SecondTime, opt => opt.MapFrom(d => d.Controls.ElementAt(1).ControlDate))
               .ForMember(m => m.FirstTime, opt => opt.MapFrom(d => d.Controls.ElementAt(0).ControlDate))
               .ForMember(m => m.ControlDate, opt => opt.MapFrom(d => d.Controls.ElementAt(0).ControlDate)).
               ForMember(x => x.EmployerAddress, opt => opt.MapFrom(cert => cert.Company.Address)).
               ForMember(x => x.EmployerName, opt => opt.MapFrom(cert => cert.Company.Fullname)).
               ForMember(x => x.FileNumber, opt => opt.MapFrom(cert => string.Format("RS={0}", cert.Controls.ElementAt(0).ControlFormId.ToString()))).
               ForMember(x => x.ReviewDate, opt => opt.MapFrom(cert => cert.RefferenceForm.Template.ReviewDate)).
               ForMember(x => x.Groups, opt => opt.MapFrom(cert => cert.RefferenceForm.Groups));

            CreateMap<Certificate, MissMatchReportModel>().
               ForMember(m => m.Address, opt => opt.MapFrom(d => d.Province.Title + "-" + d.Company.Address)).
               ForMember(m => m.Company, opt => opt.MapFrom(d => d.Company.Fullname)).
               ForMember(m => m.Properties, opt => opt.MapFrom(d => this.Prop(d.Controls.ElementAt(0).ControlForm.Groups.ElementAt(0).Answers))).
               ForMember(m => m.MissMatchWords, opt => opt.Ignore()).
               ForMember(m => m.ControlTime, opt => opt.MapFrom(d => GetControlTime(d.Controls.ElementAt(0).ControlTime))).
               ForMember(m => m.ControlDate, opt => opt.MapFrom(d => d.Controls.ElementAt(0).ControlDate)).
               ForMember(m => m.FormCode, opt => opt.MapFrom(d => d.Controls.ElementAt(0).ControlForm.Template.FormCode)).
               ForMember(m => m.FileNumber, opt => opt.MapFrom(d => string.Format("RS-{0}", d.Id)));
            #endregion

            #region ServiceType

            CreateMap<ServiceType, ServiceTypeModel>().ForMember(m => m.Department, opt => opt.MapFrom(dto => dto.Department.Title));
            CreateMap<ServiceTypeModel, ServiceType>().ForMember(d => d.DepartmentId, opt => opt.MapFrom(m => m.DepartmentId)).
                ForMember(d => d.Department, opt => opt.Ignore());
            #endregion

            CreateMap<Certificate, RequestCertificateModel>()
                .ForMember(m => m.ProvinenceId, opt => opt.MapFrom(d => d.ProvinceIdId));
            CreateMap<SavedFormData, FormDataModel>();
            CreateMap<FormTemplateAnswerColumn, string>().ConstructUsing(x => x.Title);
            CreateMap<FormTemplateQuestionHeader, string>().ConstructUsing(x => x.Title);
            CreateMap<FormTemplateRowMissMatchWord, string>().ConstructUsing(x => x.Text);
            CreateMap<FormDataRow, FormDataRowModel>().ForMember(x => x.MissMatchWords, opt => opt.MapFrom(x => x.Template.MissMatchWords))
                .ForMember(x => x.FirstQuestion, opt => opt.MapFrom(x => x.Template.FirstQuestion))
                .ForMember(x => x.SecondQuestion, opt => opt.MapFrom(x => x.Template.SecondQuestion))
                .ForMember(x => x.ThirdQuestion, opt => opt.MapFrom(x => x.Template.ThirdQuestion));

        }

        private List<string> GetMissMatchWords(Certificate d)
        {
            List<string> words = new List<string>();
            for (int i = 0; i < d.Controls.ElementAt(0).ControlForm.Groups.Count; i++)
            {
                for (int j = 0; i < d.Controls.ElementAt(0).ControlForm.Groups.ElementAt(i).Answers.Count; i++)
                {
                    ///// words.Add(d.Controls.ElementAt(0).FormData.Groups.ElementAt(i).Answers.ElementAt(j).Template.MissMatchWords);
                }

            }
            int c = words.Count;
            return words;
        }


        private object Prop(ICollection<FormDataRow> questionDatas)
        {
            return questionDatas;
        }
    }
}
