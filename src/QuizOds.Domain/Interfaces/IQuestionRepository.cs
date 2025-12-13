using QuizOds.Domain.Entities;
namespace QuizOds.Domain.Interfaces;

public interface IQuestionRepository
{
    Task AddAsync(Question question);
    Task<Question?> GetByIdAsync(Guid id);
    Task<IEnumerable<Question>> GetByQuizIdAsync(Guid quizId);
}
