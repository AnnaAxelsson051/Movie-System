using Microsoft.EntityFrameworkCore;
using MovieSystemNewest1.Model;

namespace MovieSystemNewest1.Data
{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<UserGenre> UserGenre { get; set; }

        //Generating data about genres in db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[] {
                new Genre{Id = 28,Title="Action", Description="An action movie is a fast-paced film genre that features thrilling stunts, fight scenes, and chase sequences as a hero battles against a villain or group of villains. These movies often have a strong emphasis on suspense and tension, with a plot that keeps the audience on the edge of their seats."},
                new Genre{Id = 12,Title="Adventure", Description="An adventure movie is a genre that features exciting and often dangerous journeys or quests undertaken by a hero or group of heroes. These movies often take place in exotic or fantastical locations and involve elements of exploration, discovery, and survival, with a strong emphasis on action and sometimes including elements of drama, comedy, or romance."},
                new Genre{Id = 35,Title="Comedy", Description="A comedy movie is a genre that aims to make the audience laugh and feel good through humorous situations and characters. These movies often feature witty dialogue, physical comedy, and exaggerated situations, and can include a variety of subgenres, such as romantic comedies, slapstick comedies, or satirical comedies."},
                new Genre{Id = 80,Title="Crime", Description="A crime movie is a genre that typically focuses on the investigation and resolution of criminal activities, such as murder, theft, or fraud. These movies often involve complex plots, suspenseful storytelling, and intense characters, with an emphasis on the criminal underworld and the often gritty and violent world of law enforcement."},
                new Genre{Id = 99,Title="Documentary", Description="A documentary movie is a non-fiction genre that presents real-life events, people, and issues using factual information, interviews, and archival footage. These movies aim to educate, inform, and provoke thought, often exploring important social, political, or environmental issues, or showcasing unique aspects of human experience or natural phenomena."},
                new Genre{Id = 18,Title="Drama", Description="A drama movie is a genre that focuses on realistic characters, settings, and situations, often exploring complex themes such as love, loss, or personal struggle. These movies often feature strong performances and emotional depth, with an emphasis on character development and exploring the human experience."},
                new Genre{Id = 10751,Title="Family", Description="A family movie is a genre that aims to entertain and appeal to audiences of all ages, typically featuring themes that are appropriate and engaging for children and adults. These movies often emphasize values such as friendship, teamwork, and family, and can include a variety of genres, such as animated films, adventure movies, or comedies."},
                new Genre{Id = 36,Title="History", Description="A history movie is a genre that presents real-life historical events or figures, often depicting the lives of famous individuals or the events that shaped the world. These movies can educate, inform, and entertain audiences, often presenting a dramatized or fictionalized version of events, while remaining true to the historical context and accuracy. The genre can also explore important themes, such as social justice, revolution, or war."},
                new Genre{Id = 27,Title="Horror", Description="A horror movie is a genre that aims to scare and shock audiences through the use of suspense, tension, and terrifying imagery. These movies often feature supernatural or grotesque creatures, psychological horror, or real-life threats, such as murderers or zombies. The genre can explore important themes, such as fear, the unknown, or the supernatural, and is often a popular choice for Halloween or thrill-seeking audiences."},
                new Genre{Id = 9648,Title="Mystery", Description="A mystery movie is a genre that focuses on the investigation and resolution of a mysterious or puzzling event, such as a crime or disappearance. These movies often involve suspenseful storytelling, plot twists, and complex characters, with the audience being encouraged to solve the mystery alongside the protagonist. The genre can also explore important themes, such as justice, truth, and the nature of human perception."},
                new Genre{Id = 10749,Title="Romance", Description="A romance movie is a genre that tells a love story, often featuring characters who fall in love, face obstacles, and ultimately find happiness. These movies can range from light-hearted and comedic to dramatic and emotional, and can explore themes such as passion, heartbreak, and true love. The genre often emphasizes the importance of relationships and the human desire for connection and intimacy."},
                new Genre{Id = 878,Title="Science Fiction", Description="A science fiction movie is a genre that explores imaginative or futuristic scientific and technological concepts, often depicting speculative worlds, futuristic societies, or alternate realities. These movies can feature space travel, time travel, advanced technology, or artificial intelligence, and can explore important themes such as the nature of humanity, the impact of technology on society, or the consequences of scientific experimentation. The genre often encourages viewers to imagine new possibilities and contemplate the boundaries of the unknown."},
                new Genre{Id = 53,Title="Thriller", Description="A TV thriller movie is a genre that aims to keep the audience on the edge of their seats with suspenseful and thrilling storytelling. These movies can range from crime dramas to psychological thrillers, often featuring complex characters, plot twists, and intense action. The genre can explore themes such as justice, morality, and power, and is often a popular choice for TV movie audiences who are looking for an exciting and suspenseful viewing experience."},
                new Genre{Id = 37,Title="Western", Description="A TV western movie is a genre that typically takes place in the American Old West, featuring cowboys, gunslingers, and rugged landscapes. These movies can range from classic westerns to modern takes on the genre, often exploring themes of justice, honor, and freedom. The genre can showcase action-packed shootouts, horseback riding, and gritty drama, and is often a popular choice for TV movie audiences who enjoy the wild, untamed spirit of the American West."}
            });
        }
    }
}
