using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class ErrorModel
    {
        public List<string> Errors { get; } = new List<string>();

        public ErrorModel(string erro)
        {
            Errors.Add(erro);
        }

        public ErrorModel(IEnumerable<string> erros)
        {
            Errors.AddRange(erros);
        }

        public ErrorModel(IReadOnlyCollection<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                Errors.Add(notification.Message);
            }
        }
    }
}
