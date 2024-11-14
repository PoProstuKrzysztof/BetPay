using Domain.Enums;
using Syncfusion.Blazor.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Functions;
public static class ShowToastGridOperations
{
    public static async Task<SfToast> ShowToastGridOperation(SfToast toastObject, ToastTypeEnum typeEnum, string? content)
    {
        switch (typeEnum)
        {
            case ToastTypeEnum.Succes:
                toastObject.CssClass = "e-toast-success";
                toastObject.Content =  !string.IsNullOrWhiteSpace(content) ? content : "Operation was succesfull.";
                toastObject.Title = "Success!";
                await toastObject.ShowAsync();
                return toastObject;

            case ToastTypeEnum.Failed:
                toastObject.CssClass = "e-toast-danger";
                toastObject.Content = !string.IsNullOrWhiteSpace(content) ? content : "Something went wrong. Try again or contact administrator.";
                toastObject.Title = "Failed";
                await toastObject.ShowAsync();
                return toastObject;
            case ToastTypeEnum.Information:
                toastObject.CssClass = "e-toast-info";
                toastObject.Content = !string.IsNullOrWhiteSpace(content) ? content : "";
                toastObject.Title = "Information";
                await toastObject.ShowAsync();
                return toastObject;
            case ToastTypeEnum.Warning:
                toastObject.CssClass = "e-toast-warning";
                toastObject.Content = !string.IsNullOrWhiteSpace(content) ? content : "";
                toastObject.Title = "Warning";
                await toastObject.ShowAsync();
                return toastObject;

            default:
                toastObject.CssClass = "e-toast-danger";
                toastObject.Content = "Something went wrong. Try again or contact administrator.";
                toastObject.Title = "Error";
                await toastObject.ShowAsync();
                return toastObject;
        }
    }
}
