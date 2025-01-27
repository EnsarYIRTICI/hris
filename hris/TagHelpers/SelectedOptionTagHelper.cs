using Microsoft.AspNetCore.Razor.TagHelpers;

namespace hris.TagHelpers
{
    [HtmlTargetElement("option", Attributes = "asp-for-selected")]
    public class SelectedOptionTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for-selected")]
        public bool IsSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsSelected)
            {
                output.Attributes.SetAttribute("selected", "selected");
            }
        }
    }
}
