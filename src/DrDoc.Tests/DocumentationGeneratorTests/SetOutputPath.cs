using DrDoc.Generation;
using NUnit.Framework;
using Rhino.Mocks;
using Is=Rhino.Mocks.Constraints.Is;

namespace DrDoc.Tests.DocumentationGeneratorTests
{
    [TestFixture]
    public class SetOutputPath : BaseDocumentationGeneratorFixture
    {
        [Test]
        public void should_pass_output_path_to_writer_if_set()
        {
            var writer = MockRepository.GenerateMock<IBulkPageWriter>();
            var generator = new DocumentationGenerator(StubAssemblyLoader, StubXmlLoader, StubParser, writer, StubResourceManager);

            generator.SetOutputPath("output-path");
            generator.Generate();

            writer.AssertWasCalled(x => x.CreatePagesFromDirectory(null, null, null),
                                   x => x.Constraints(Is.Anything(), Is.Equal("output-path"), Is.Anything()));
        }

        [Test]
        public void should_pass_default_output_path_to_writer_if_not_set()
        {
            var writer = MockRepository.GenerateMock<IBulkPageWriter>();
            var generator = new DocumentationGenerator(StubAssemblyLoader, StubXmlLoader, StubParser, writer, StubResourceManager);

            generator.Generate();

            writer.AssertWasCalled(x => x.CreatePagesFromDirectory(null, null, null),
                                   x => x.Constraints(Is.Anything(), Is.Equal("output"), Is.Anything()));
        }
    }
}