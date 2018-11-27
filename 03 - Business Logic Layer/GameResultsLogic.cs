using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class GameResultsLogic : BaseLogic
    {
        public List<GameResultModel> GetAllGameResults() // Gets all the game results as a list
        {
            return DB.GameResults.Select(f => new GameResultModel
            {
                gameSpan = f.GameTime,
                gameTime = f.GameDateTime,
                id = f.GameResultID,
                steps = f.StepNumber,
                userId = f.UserID
            }).ToList();
        }

        public GameResultModel GetOneGameResult(int id) // Gets one game result from the DB
        {
            return DB.GameResults.Where(f => f.GameResultID == id).Select(f => new GameResultModel
            {
                id = f.GameResultID,
                userId = f.UserID,
                gameSpan = f.GameTime,
                gameTime = f.GameDateTime,
                steps = f.StepNumber
            }).SingleOrDefault();
        }

        public GameResultModel AddGameResult(GameResultModel gameResultModel) // Adds a single game result.
        {
            GameResult gameResult = new GameResult
            {
                UserID = gameResultModel.userId,
                StepNumber = gameResultModel.steps,
                GameDateTime = gameResultModel.gameTime,
                GameTime = gameResultModel.gameSpan
            };

            DB.GameResults.Add(gameResult);
            DB.SaveChanges();

            gameResultModel.id = gameResult.GameResultID;

            return GetOneGameResult(gameResultModel.id);
        }
    }
}
