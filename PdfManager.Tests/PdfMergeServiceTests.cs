using System;
using Xunit;
using PdfManager.Services;

namespace PdfManager.Tests
{
    public class PdfMergeServiceTests
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void PdfMerge_ShouldMergeTwoFiles()
        {
            var pdfMergeService = new PdfMergeService();
            var result = pdfMergeService.MergeFiles(new string[] { "" });
            Assert.Equal(result, "Done");
        }
   }
}