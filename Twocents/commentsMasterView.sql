CREATE VIEW `commentsMasterView` AS
	SELECT comments.*, 
    commentRatings.rating, commentRatings.voteTypeId, 
    voteTypes.name, voteTypes.description, 
    sourceTypes.name, edits.date
    FROM comments
		JOIN commentRatings
			ON commentRatings.commentId = comments.id
		JOIN voteTypes
			ON voteTypes.voteTypeId = commentRatings.voteTypeId
		JOIN commentSources
			ON commentSources.commentSourceId = comments.sourceid
		JOIN sourceTypes
			ON sourceTypes.sourceTypeId = commentSources.typeid
		JOIN edits
			ON edits.editId = comments.editId