using QuizOds.Domain.Entities;

namespace QuizOds.Infrastructure.Data;

public static class QuizOdsDbSeeder
{
    public static void Seed(QuizOdsDbContext context)
    {
        if (context.Ods.Any())
            return;

        var odsList = GetOds();
        context.Ods.AddRange(odsList);
        context.SaveChanges();

        foreach (var ods in odsList)
        {
            var quiz = new Quiz
            {
                Id = Guid.NewGuid(),
                OdsId = ods.Id,
                Ods = ods
            };

            context.Quizzes.Add(quiz);

            var questions = GetQuestionsByOds(ods.Numero, quiz.Id);
            context.Questions.AddRange(questions);
        }

        context.SaveChanges();
    }

    // =========================
    // ODS
    // =========================
    private static List<Ods> GetOds() => new()
    {
        CreateOds(1, "Erradicação da Pobreza"),
        CreateOds(2, "Fome Zero e Agricultura Sustentável"),
        CreateOds(3, "Saúde e Bem-Estar"),
        CreateOds(4, "Educação de Qualidade"),
        CreateOds(5, "Igualdade de Gênero"),
        CreateOds(6, "Água Potável e Saneamento"),
        CreateOds(7, "Energia Limpa e Acessível"),
        CreateOds(8, "Trabalho Decente e Crescimento Econômico"),
        CreateOds(9, "Indústria, Inovação e Infraestrutura"),
        CreateOds(10, "Redução das Desigualdades"),
        CreateOds(11, "Cidades e Comunidades Sustentáveis"),
        CreateOds(12, "Consumo e Produção Responsáveis"),
        CreateOds(13, "Ação Contra a Mudança do Clima"),
        CreateOds(14, "Vida na Água"),
        CreateOds(15, "Vida Terrestre"),
        CreateOds(16, "Paz, Justiça e Instituições Eficazes"),
        CreateOds(17, "Parcerias e Meios de Implementação")
    };

    private static Ods CreateOds(int numero, string titulo) => new()
    {
        Id = Guid.NewGuid(),
        Numero = numero,
        Titulo = $"ODS {numero} - {titulo}",
        Resumo = $"Resumo da ODS {numero}.",
        Conteudo = $"Conteúdo completo explicando a ODS {numero}.",
        ImageUrl = $"https://www.un.org/sustainabledevelopment/wp-content/uploads/2019/08/E-Goal-{numero:D2}.png"
    };

    // =========================
    // QUESTIONS
    // =========================
    private static List<Question> GetQuestionsByOds(int odsNumero, Guid quizId)
    {
        return new List<Question>
        {
            new()
            {
                Id = Guid.NewGuid(),
                QuizId = quizId,
                Texto = $"A ODS {odsNumero} está relacionada a qual objetivo?",
                OptionA = "Desenvolvimento social",
                OptionB = "Educação",
                OptionC = "Economia",
                OptionD = "Tecnologia",
                RespostaCorreta = 'A'
            },
            new()
            {
                Id = Guid.NewGuid(),
                QuizId = quizId,
                Texto = $"Qual ação contribui diretamente para a ODS {odsNumero}?",
                OptionA = "Ação sustentável",
                OptionB = "Desmatamento",
                OptionC = "Poluição",
                OptionD = "Desigualdade",
                RespostaCorreta = 'A'
            },
            new()
            {
                Id = Guid.NewGuid(),
                QuizId = quizId,
                Texto = $"A ODS {odsNumero} faz parte de qual agenda?",
                OptionA = "Agenda 2030",
                OptionB = "Agenda 2050",
                OptionC = "ONU 2000",
                OptionD = "Plano Global",
                RespostaCorreta = 'A'
            }
        };
    }
}
