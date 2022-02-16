﻿using Conduit.Comments.Domain.Comments.Domain;
using Conduit.Comments.Domain.Comments.Queries.Single;
using Conduit.Shared.Validation;

namespace Conduit.Comments.Domain.Comments.Create;

public class CommentCreateResponse : BaseResponse
{
    public Validation? Validation { get; set; }

    public CommentCreateResponse(
        Validation validation)
    {
        Validation = validation;
        Error = Error.BadRequest;
    }

    public CommentCreateResponse()
    {
    }

    public CommentCreateResponse(
        Error error)
    {
        Error = error;
    }

    public CommentCreateResponse(
        CommentOutputModel comment)
    {
        Output = new SingleCommentOutputModel() { Comment = comment };
    }

    public SingleCommentOutputModel Output { get; set; } = new();
}
