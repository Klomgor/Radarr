using FluentValidation;
using NzbDrone.Common.Extensions;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.Movies;
using NzbDrone.Core.Validation;
using NzbDrone.Core.Validation.Paths;

namespace NzbDrone.Core.AutoTagging.Specifications
{
    public class RootFolderSpecificationValidator : AbstractValidator<RootFolderSpecification>
    {
        public RootFolderSpecificationValidator()
        {
            RuleFor(c => c.Value).IsValidPath();
        }
    }

    public class RootFolderSpecification : AutoTaggingSpecificationBase
    {
        private static readonly RootFolderSpecificationValidator Validator = new ();

        public override int Order => 1;
        public override string ImplementationName => "Root Folder";

        [FieldDefinition(1, Label = "AutoTaggingSpecificationRootFolder", Type = FieldType.RootFolder)]
        public string Value { get; set; }

        protected override bool IsSatisfiedByWithoutNegate(Movie movie)
        {
            return movie.RootFolderPath.PathEquals(Value);
        }

        public override NzbDroneValidationResult Validate()
        {
            return new NzbDroneValidationResult(Validator.Validate(this));
        }
    }
}
