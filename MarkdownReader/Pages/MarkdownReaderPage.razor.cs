namespace MarkdownReader.Pages
{
    using MarkdownReader.Services;
    using Markdig;
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public partial class MarkdownReaderPage
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "gitpath")]
        public string GitPath { get; set; }

        [Inject]
        public IFileReader FileReader { get; set; }
        public string Body { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(GitPath))
            {
                var markdownContent = await FileReader.ReadFile(GitPath);
                Body = Markdown.ToHtml(markdownContent);
            }
        }
    }
}
