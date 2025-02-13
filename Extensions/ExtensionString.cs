using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;
using HtmlAgilityPack;

namespace Extensions
{
    public static class ExtensionString
    {
        public static string ToAliasString(this string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value))
                    return string.Empty;
                value = value.Replace("đ", "d").Replace("Đ", "d");

                // Replace dashes with spaces
                value = value.Replace("-", " ");

                // Normalize and remove diacritic marks (non-spacing marks)
                var normalizedString = value.Normalize(NormalizationForm.FormD);

                var stringBuilder = new StringBuilder();

                foreach (var c in normalizedString)
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    {
                        stringBuilder.Append(c);
                    }
                }

                // Get the sanitized version
                var result = stringBuilder.ToString();

                // Remove non-alphanumeric characters except spaces
                result = Regex.Replace(result, "[^a-zA-Z0-9 ]", "");

                // Replace multiple spaces with a single space and trim
                result = Regex.Replace(result, @"\s+", " ").Trim();

                // Replace spaces with dashes and convert to lowercase
                return result.Replace(" ", "-").ToLower();
            }
            catch (Exception ex)
            {
                // Log exception for debugging
                Console.WriteLine($"Error in ToAliasString: {ex.Message}");
                return string.Empty;
            }
        }
        public static string ToTextFromHtml(this string input)
        {
            try
            {
                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(input);

                var textContent = string.Join(" ", htmlDoc.DocumentNode.Descendants().Where(node => node.NodeType == HtmlNodeType.Text && !string.IsNullOrWhiteSpace(node.InnerText)).Select(node => node.InnerText.Trim()));

                if (textContent.Length > 230)
                    return textContent.Substring(0, 230) + " ...";

                return textContent;
            }
            catch
            {
                return "Loading ...";
            }
        }
    }
}
