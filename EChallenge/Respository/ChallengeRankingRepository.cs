using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Respository
{
    public class ChallengeRankingRepository
    {

        public ICollection<ChallengeRankingViewModel> GetAllChallengeRanking()
        {
            var entities = new EChallengeEntities();
            return (from ucr in entities.ChallengeRankings
                    group ucr by ucr.ChallegneId into g
                    select new ChallengeRankingViewModel
                    {
                        ChallengeId = (int)g.Select(ucr => ucr.ChallegneId).FirstOrDefault(),
                        ChallengeRanking = (double)g.Average(ucr => ucr.Ranking),
                        Challenge = g.Select(ucr => ucr.Challenge).FirstOrDefault()
                    }).ToList();
        }


        public ICollection<ChallengeRanking> GetChallengeRankingByChallengeId(int challengeId)
        {
            var entities = new EChallengeEntities();
            return entities.ChallengeRankings.Where(c => c.ChallegneId == challengeId).ToList();
        }

        public void AddUserChallengeRanking(ChallengeRanking model)
        {
            model.RankingDate = DateTime.Now;
            using (var entities = new EChallengeEntities())
            {
                entities.ChallengeRankings.Add(model);
                entities.SaveChanges();
            }
        }


        public void UpdateChallengeRanking(ChallengeRanking model)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingChallengeRanking = entities.ChallengeRankings.Where(c => c.ChallengeRankingId == model.ChallengeRankingId).FirstOrDefault();

                if (existingChallengeRanking == null)
                    throw new NullReferenceException("existingChallengeRanking not found");

                existingChallengeRanking.ChallegneId = model.ChallegneId;
                existingChallengeRanking.Ranking = model.Ranking;
                existingChallengeRanking.RankingGivenByUserId = model.RankingGivenByUserId;
                existingChallengeRanking.RankingDate = DateTime.UtcNow;
                entities.SaveChanges();
            }
        }


        public void DeleteChallengeRanking(int challengeRankingId)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingUserRanking = entities.ChallengeRankings.Where(c => c.ChallengeRankingId == challengeRankingId).FirstOrDefault();

                if (existingUserRanking == null)
                    throw new NullReferenceException("User not found");

                entities.ChallengeRankings.Remove(existingUserRanking);
                entities.SaveChanges();
            }
        }
    }
}