using ManagementChatTelegram.Data;
using ManagementChatTelegram.Features.Command;
using MediatR;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace ManagementChatTelegram.Features.Handler
{
    public class CreateImageHandler : IRequestHandler<CreateImage, Bitmap>
    {
        public Task<Bitmap> Handle(CreateImage request, CancellationToken cancellationToken)
        {
            using (Bitmap bmp = (Bitmap)Image.FromFile("template.png"))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    int x = 300, y = 380;
                    foreach (var leader in request.Leaders)
                    {
                        using (Font Font = new Font("Segoe UI", 9, FontStyle.Bold))
                        {
                            g.DrawString(leader.AccountId, Font, Brushes.Maroon, x, y);
                        }

                        using (Font Font = new Font("Segoe UI", 9, FontStyle.Bold))
                        {
                            g.DrawString(leader.Rating, Font, Brushes.Maroon, x + 500, y);
                        }

                        y += 60;
                    }

                    using (Font Font = new Font("Segoe UI", 6, FontStyle.Regular))
                    {
                        g.DrawString($"Лидеры {Season.Number} сезона ({System.DateTime.Now})", Font, Brushes.Gray, x, y + 100);
                    }
                }

                bmp.Save("LeaderBord.png");

                return Task.FromResult(bmp);
            }
        }
    }
}
