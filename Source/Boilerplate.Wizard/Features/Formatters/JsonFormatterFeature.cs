﻿namespace Boilerplate.Wizard.Features
{
    using System.Threading.Tasks;
    using Boilerplate.Wizard.Services;

    public class JsonFormatterFeature : MultiChoiceFeature
    {
        private const string StartupFormattersCs = "Startup.Formatters.cs";

        private readonly IFeatureItem camelCase;
        private readonly IFeatureItem none;
        private readonly IFeatureItem titleCase;

        public JsonFormatterFeature(IProjectService projectService)
            : base(projectService)
        {
            this.camelCase = new FeatureItem(
                "CamelCase",
                "Camel-Case (e.g. camelCase)",
                "The first character of the variable starts with a lower-case. Each word in the variable name after that starts with an upper-case character.",
                1)
            {
                IsSelected = true
            };
            this.Items.Add(this.camelCase);

            this.titleCase = new FeatureItem(
                "TitleCase",
                "Title Case (e.g. TitleCase)",
                "Each word in the variable name starts with an upper-case character.",
                2);
            this.Items.Add(this.titleCase);

            this.none = new FeatureItem(
                "None",
                "None",
                "Removes the JSON formatter.",
                3);
            this.Items.Add(none);
        }

        public override string Description
        {
            get { return "Choose whether to use the JSON input/output formatter and whether it should use camel or title casing."; }
        }

        public override IFeatureGroup Group
        {
            get { return FeatureGroups.Formatters; }
        }

        public override string Id
        {
            get { return "JsonFormatter"; }
        }

        public override int Order
        {
            get { return 1; }
        }

        public override string Title
        {
            get { return "JSON Formatter"; }
        }

        public override async Task AddOrRemoveFeature()
        {
            if (this.camelCase.IsSelected)
            {
                await this.ProjectService.EditComment(
                    this.camelCase.CommentName,
                    EditCommentMode.LeaveCodeUnchanged,
                    StartupFormattersCs);
                await this.ProjectService.EditComment(
                    this.titleCase.CommentName,
                    EditCommentMode.DeleteCode,
                    StartupFormattersCs);
                await this.ProjectService.EditComment(
                    this.none.CommentName,
                    EditCommentMode.DeleteCode,
                    StartupFormattersCs);
            }
            else if (this.titleCase.IsSelected)
            {
                await this.ProjectService.EditComment(
                    this.camelCase.CommentName,
                    EditCommentMode.LeaveCodeUnchanged,
                    StartupFormattersCs);
                await this.ProjectService.EditComment(
                    this.titleCase.CommentName,
                    EditCommentMode.DeleteCode,
                    StartupFormattersCs);
                await this.ProjectService.EditComment(
                    this.none.CommentName,
                    EditCommentMode.DeleteCode,
                    StartupFormattersCs);
            }
            else if (this.none.IsSelected)
            {
                await this.ProjectService.EditComment(
                    this.camelCase.CommentName,
                    EditCommentMode.LeaveCodeUnchanged,
                    StartupFormattersCs);
                await this.ProjectService.EditComment(
                    this.titleCase.CommentName,
                    EditCommentMode.DeleteCode,
                    StartupFormattersCs);
                await this.ProjectService.EditComment(
                    this.none.CommentName,
                    EditCommentMode.DeleteCode,
                    StartupFormattersCs);
            }
        }
    }
}