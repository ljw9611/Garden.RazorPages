using Garden.Models;
using Garden.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Garden.Pages.Protfolio
{
    public class IndexModel : PageModel
    {
        private readonly PortfolioServiceJsonFile _service;

        // �������� �Ű� ������ ����(�������丮) Ŭ���� ����
        public IndexModel(PortfolioServiceJsonFile service)
        {
            this._service = service;
        }

        public IEnumerable<Portfolio> Portfolios { get; private set; }

        public void OnGet()
        {
            Portfolios = _service.GetPortfolios();
        }
    }
}
