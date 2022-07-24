Cliffs:

There was some ambiguity in the project description like:

Why is there DateCreated in the incoming data model?

Should I calculate ProductTurnoverBreakdown as sum of all ProductTurnover data created in same year?
  
What do we do if ProductTurnover with same EAN as existing comes, but different grossturnover? Should gross turnover breakdown be recalculated? 
     
Should the seeding of database have been done via migraitons and in code?

Caching requirements?

I don't have experiense with using cache, but I suppose it must be populated on project load in case of unexpected shutdown.

I chose to break down JurisdictionService and Jurisdiction into separate structures for more robust unit testing.
Having that in mind, I chose the simpler way of creating the demo in order to save time for ourselfs.
