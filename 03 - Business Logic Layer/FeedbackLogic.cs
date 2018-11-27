using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class FeedbackLogic : BaseLogic
    {
        public List<FeedbackModel> GetAllFeedbacks() // Gets a list of feedbacks.
        {
            List<FeedbackModel> feedbacks = DB.Feedbacks.Select(f => new FeedbackModel
            {
                feedbackID = f.FeedbackID,
                feedbackText = f.FeedbackText,
                dateHour = f.DateHour,
                userID = f.UserID
            }).ToList();
            return feedbacks;

        }

        public FeedbackModel GetOneFeedback(int id) // Gets one feedback from the DB and returns it.
        {
            return DB.Feedbacks.Where(f => f.FeedbackID == id).Select(f => new FeedbackModel
            {
                dateHour = f.DateHour,
                userID = f.UserID,
                feedbackID = f.FeedbackID,
                feedbackText = f.FeedbackText
            }).SingleOrDefault();
        }

        public FeedbackModel AddFeedback(FeedbackModel feedbackModel) // Adds a single feedback and returns it.
        {
            Feedback feedback = new Feedback
            {
                FeedbackText = feedbackModel.feedbackText,
                DateHour = feedbackModel.dateHour,
                UserID = feedbackModel.userID,

            };
            DB.Feedbacks.Add(feedback);
            DB.SaveChanges();

            feedbackModel.feedbackID = feedback.FeedbackID;
            return GetOneFeedback(feedbackModel.feedbackID);
        }

    }
}
