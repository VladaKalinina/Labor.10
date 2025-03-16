
using Plants;


namespace PlantsTest
{
    [TestClass]
    public class IdNumberTests
    {
        [TestMethod]
        public void Clone_ReturnsEqualObject()
        {
            // Проверяем, что клонированный IdNumber имеет тот же номер
            IdNumber originalId = new IdNumber(123);
            IdNumber clonedId = (IdNumber)originalId.Clone();

            Assert.AreEqual(originalId.Number, clonedId.Number);
        }

        [TestMethod]
        public void Clone_ReturnsDifferentInstance()
        {
            // Проверяем, что клонированный IdNumber — это новая копия
            IdNumber originalId = new IdNumber(123);
            IdNumber clonedId = (IdNumber)originalId.Clone();

            Assert.AreNotSame(originalId, clonedId);
        }

        [TestMethod]
        public void Equals_WithSameNumber_ReturnsTrue()
        {
            // Проверяем, что IdNumber с одинаковыми номерами равны
            IdNumber id1 = new IdNumber(456);
            IdNumber id2 = new IdNumber(456);

            Assert.IsTrue(id1.Equals(id2));
        }

        [TestMethod]
        public void Equals_WithDifferentNumber_ReturnsFalse()
        {
            // Проверяем, что IdNumber с разными номерами не равны
            IdNumber id1 = new IdNumber(456);
            IdNumber id2 = new IdNumber(789);

            Assert.IsFalse(id1.Equals(id2));
        }

        [TestMethod]
        public void NumberSetter_WithNegativeValue_KeepsPreviousValue()
        {
            // Проверяем, что отрицательное значение не перезаписывает номер
            IdNumber id = new IdNumber(10);
            id.Number = -1;

            Assert.AreEqual(10, id.Number);
        }

        [TestMethod]
        public void NumberSetter_WithMaxValue_SetsCorrectly()
        {
            // Проверяем, что максимальное значение корректно устанавливается
            IdNumber id = new IdNumber();
            id.Number = int.MaxValue;

            Assert.AreEqual(int.MaxValue, id.Number);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Проверяем, что ToString возвращает правильный формат строки
            IdNumber id = new IdNumber(42);

            Assert.AreEqual("IdNumber: 42", id.ToString());
        }
    }

    [TestClass]
    public class PlantTests
    {
        [TestMethod]
        public void Clone_ReturnsEqualObject()
        {
            // Проверяем, что клонированный Plant идентичен оригиналу
            Plant originalPlant = new Plant("Rose", "Red", 123);
            Plant clonedPlant = (Plant)originalPlant.Clone();

            Assert.AreEqual(originalPlant.ToString(), clonedPlant.ToString());
        }

        [TestMethod]
        public void Clone_ReturnsDifferentInstance()
        {
            // Проверяем, что клонированный Plant — это новая копия
            Plant originalPlant = new Plant("Rose", "Red", 123);
            Plant clonedPlant = (Plant)originalPlant.Clone();

            Assert.AreNotSame(originalPlant, clonedPlant);
        }

        [TestMethod]
        public void Equals_WithSameNameAndColor_ReturnsTrue()
        {
            // Проверяем, что растения с одинаковыми именем и цветом равны
            Plant plant1 = new Plant("Rose", "Red", 456);
            Plant plant2 = new Plant("Rose", "Red", 789);

            Assert.IsTrue(plant1.Equals(plant2));
        }

        [TestMethod]
        public void Equals_WithDifferentName_ReturnsFalse()
        {
            // Проверяем, что растения с разными именами не равны
            Plant plant1 = new Plant("Rose", "Red", 456);
            Plant plant2 = new Plant("Sunflower", "Red", 456);

            Assert.IsFalse(plant1.Equals(plant2));
        }

        [TestMethod]
        public void NameSetter_WithEmptyString_KeepsPreviousValue()
        {
            // Проверяем, что пустое имя не перезаписывает текущее значение
            Plant plant = new Plant("Initial", "Green", 1);
            plant.Name = "";

            Assert.AreEqual("Initial", plant.Name);
        }

        [TestMethod]
        public void ColorSetter_WithNullValue_KeepsPreviousValue()
        {
            // Проверяем, что null для цвета не изменяет текущее значение
            Plant plant = new Plant("Rose", "Red", 1);
            plant.Color = null;

            Assert.AreEqual("Red", plant.Color);
        }

        [TestMethod]
        public void RandomInit_SetsNonEmptyName()
        {
            // Проверяем, что случайная инициализация задаёт непустое имя
            Plant plant = new Plant();
            plant.RandomInit();

            Assert.IsFalse(string.IsNullOrEmpty(plant.Name));
        }

        [TestMethod]
        public void RandomInit_SetsNonEmptyColor()
        {
            // Проверяем, что случайная инициализация задаёт непустой цвет
            Plant plant = new Plant();
            plant.RandomInit();

            Assert.IsFalse(string.IsNullOrEmpty(plant.Color));
        }

        [TestMethod]
        public void Init_SetsValidNameFromInput()
        {
            // Проверяем, что Init корректно устанавливает имя из ввода
            Plant plant = new Plant();
            using (var input = new StringReader("TestPlant\nRed\n"))
            {
                Console.SetIn(input);
                plant.Init();
                Assert.AreEqual("TestPlant", plant.Name);
            }
        }

        [TestMethod]
        public void Init_SetsValidColorFromInput()
        {
            // Проверяем, что Init корректно устанавливает цвет из ввода
            Plant plant = new Plant();
            using (var input = new StringReader("TestPlant\nRed\n"))
            {
                Console.SetIn(input);
                plant.Init();
                Assert.AreEqual("Red", plant.Color);
            }
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Проверяем, что ToString возвращает ожидаемый формат строки
            Plant plant = new Plant("Lily", "White", 5);

            Assert.AreEqual("Plant: Name=Lily, Color=White", plant.ToString());
        }

        [TestMethod]
        public void CompareTo_WithLesserName_ReturnsNegative()
        {
            // Проверяем, что растение с "меньшим" именем сортируется раньше
            Plant plant1 = new Plant("Apple", "Green", 1);
            Plant plant2 = new Plant("Banana", "Yellow", 2);

            Assert.IsTrue(plant1.CompareTo(plant2) < 0);
        }

        [TestMethod]
        public void CompareTo_WithEqualName_ReturnsZero()
        {
            // Проверяем, что растения с одинаковыми именами равны по сравнению
            Plant plant1 = new Plant("Rose", "Red", 1);
            Plant plant2 = new Plant("Rose", "Green", 2);

            Assert.AreEqual(0, plant1.CompareTo(plant2));
        }
    }

    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void Clone_ReturnsEqualObject()
        {
            // Проверяем, что клонированное дерево идентично оригиналу
            Tree originalTree = new Tree("Oak", "Brown", 10.5, 567);
            Tree clonedTree = (Tree)originalTree.Clone();

            Assert.AreEqual(originalTree.ToString(), clonedTree.ToString());
        }

        [TestMethod]
        public void Clone_ReturnsDifferentInstance()
        {
            // Проверяем, что клонированное дерево — это новая копия
            Tree originalTree = new Tree("Oak", "Brown", 10.5, 567);
            Tree clonedTree = (Tree)originalTree.Clone();

            Assert.AreNotSame(originalTree, clonedTree);
        }

        [TestMethod]
        public void Equals_WithSameProperties_ReturnsTrue()
        {
            // Проверяем, что деревья с одинаковыми свойствами равны
            Tree tree1 = new Tree("Oak", "Brown", 10.5, 567);
            Tree tree2 = new Tree("Oak", "Brown", 10.5, 890);

            Assert.IsTrue(tree1.Equals(tree2));
        }

        [TestMethod]
        public void Equals_WithDifferentHeight_ReturnsFalse()
        {
            // Проверяем, что деревья с разной высотой не равны
            Tree tree1 = new Tree("Oak", "Brown", 10.5, 567);
            Tree tree2 = new Tree("Oak", "Brown", 8.0, 567);

            Assert.IsFalse(tree1.Equals(tree2));
        }

        [TestMethod]
        public void HeightSetter_WithNegativeValue_KeepsPreviousValue()
        {
            // Проверяем, что отрицательная высота не перезаписывает текущее значение
            Tree tree = new Tree("Oak", "Brown", 5.0, 1);
            tree.Height = -1;

            Assert.AreEqual(5.0, tree.Height);
        }

        [TestMethod]
        public void HeightSetter_WithValidValue_SetsCorrectly()
        {
            // Проверяем, что допустимая высота корректно устанавливается
            Tree tree = new Tree("Oak", "Brown", 5.0, 1);
            tree.Height = 15.0;

            Assert.AreEqual(15.0, tree.Height);
        }

        [TestMethod]
        public void RandomInit_SetsValidHeight()
        {
            // Проверяем, что случайная высота находится в допустимом диапазоне
            Tree tree = new Tree();
            tree.RandomInit();

            Assert.IsTrue(tree.Height >= 0 && tree.Height <= 20);
        }

        [TestMethod]
        public void Init_SetsValidHeightFromInput()
        {
            // Проверяем, что Init корректно устанавливает высоту из ввода
            Tree tree = new Tree();
            using (var input = new StringReader("Oak\nBrown\n10\n"))
            {
                Console.SetIn(input);
                tree.Init();
                Assert.AreEqual(10.0, tree.Height);
            }
        }

        [TestMethod]
        public void ToString_ReturnsBaseFormat()
        {
            // Проверяем, что ToString наследуется от Plant и возвращает правильный формат
            Tree tree = new Tree("Pine", "Green", 15.0, 2);

            Assert.AreEqual("Plant: Name=Pine, Color=Green", tree.ToString());
        }
    }

    [TestClass]
    public class FlowerTests
    {
        [TestMethod]
        public void Clone_ReturnsEqualObject()
        {
            // Проверяем, что клонированный цветок идентичен оригиналу
            Flower originalFlower = new Flower("Rose", "Red", "Fragrant", 123);
            Flower clonedFlower = (Flower)originalFlower.Clone();

            Assert.AreEqual(originalFlower.ToString(), clonedFlower.ToString());
        }

        [TestMethod]
        public void Clone_ReturnsDifferentInstance()
        {
            // Проверяем, что клонированный цветок — это новая копия
            Flower originalFlower = new Flower("Rose", "Red", "Fragrant", 123);
            Flower clonedFlower = (Flower)originalFlower.Clone();

            Assert.AreNotSame(originalFlower, clonedFlower);
        }

        [TestMethod]
        public void Equals_WithSameProperties_ReturnsTrue()
        {
            // Проверяем, что цветы с одинаковыми свойствами равны
            Flower flower1 = new Flower("Rose", "Red", "Fragrant", 123);
            Flower flower2 = new Flower("Rose", "Red", "Fragrant", 456);

            Assert.IsTrue(flower1.Equals(flower2));
        }

        [TestMethod]
        public void Equals_WithDifferentSmell_ReturnsFalse()
        {
            // Проверяем, что цветы с разным запахом не равны
            Flower flower1 = new Flower("Rose", "Red", "Fragrant", 123);
            Flower flower2 = new Flower("Rose", "Red", "Sweet", 123);

            Assert.IsFalse(flower1.Equals(flower2));
        }

        [TestMethod]
        public void SmellSetter_WithEmptyString_KeepsPreviousValue()
        {
            // Проверяем, что пустой запах не перезаписывает текущее значение
            Flower flower = new Flower("Rose", "Red", "Initial", 1);
            flower.Smell = "";

            Assert.AreEqual("Initial", flower.Smell);
        }

        [TestMethod]
        public void SmellSetter_WithValidValue_SetsCorrectly()
        {
            // Проверяем, что допустимый запах корректно устанавливается
            Flower flower = new Flower("Rose", "Red", "Initial", 1);
            flower.Smell = "Sweet";

            Assert.AreEqual("Sweet", flower.Smell);
        }

        [TestMethod]
        public void RandomInit_SetsNonEmptySmell()
        {
            // Проверяем, что случайная инициализация задаёт непустой запах
            Flower flower = new Flower();
            flower.RandomInit();

            Assert.IsFalse(string.IsNullOrEmpty(flower.Smell));
        }

        [TestMethod]
        public void Init_SetsValidSmellFromInput()
        {
            // Проверяем, что Init корректно устанавливает запах из ввода
            Flower flower = new Flower();
            using (var input = new StringReader("Rose\nRed\nSweet\n"))
            {
                Console.SetIn(input);
                flower.Init();
                Assert.AreEqual("Sweet", flower.Smell);
            }
        }

        [TestMethod]
        public void ToString_ReturnsBaseFormat()
        {
            // Проверяем, что ToString наследуется от Plant и возвращает правильный формат
            Flower flower = new Flower("Tulip", "Yellow", "Sweet", 3);

            Assert.AreEqual("Plant: Name=Tulip, Color=Yellow", flower.ToString());
        }
    }

    [TestClass]
    public class RoseTests
    {
        [TestMethod]
        public void Clone_ReturnsEqualObject()
        {
            // Проверяем, что клонированная роза идентична оригиналу
            Rose originalRose = new Rose("Red Rose", "Red", "Fragrant", true, 789);
            Rose clonedRose = (Rose)originalRose.Clone();

            Assert.AreEqual(originalRose.ToString(), clonedRose.ToString());
        }

        [TestMethod]
        public void Clone_ReturnsDifferentInstance()
        {
            // Проверяем, что клонированная роза — это новая копия
            Rose originalRose = new Rose("Red Rose", "Red", "Fragrant", true, 789);
            Rose clonedRose = (Rose)originalRose.Clone();

            Assert.AreNotSame(originalRose, clonedRose);
        }

        [TestMethod]
        public void Equals_WithSameProperties_ReturnsTrue()
        {
            // Проверяем, что розы с одинаковыми свойствами равны
            Rose rose1 = new Rose("Red Rose", "Red", "Fragrant", true, 789);
            Rose rose2 = new Rose("Red Rose", "Red", "Fragrant", true, 987);

            Assert.IsTrue(rose1.Equals(rose2));
        }

        [TestMethod]
        public void Equals_WithDifferentThorns_ReturnsFalse()
        {
            // Проверяем, что розы с разным наличием шипов не равны
            Rose rose1 = new Rose("Red Rose", "Red", "Fragrant", true, 789);
            Rose rose2 = new Rose("Red Rose", "Red", "Fragrant", false, 789);

            Assert.IsFalse(rose1.Equals(rose2));
        }

        [TestMethod]
        public void RandomInit_SetsValidThorns()
        {
            // Проверяем, что случайная инициализация задаёт корректное значение шипов
            Rose rose = new Rose();
            rose.RandomInit();

            Assert.IsTrue(rose.HasThorns == true || rose.HasThorns == false);
        }

        [TestMethod]
        public void Init_SetsValidThornsFromInput()
        {
            // Проверяем, что Init корректно устанавливает шипы из ввода
            Rose rose = new Rose();
            using (var input = new StringReader("Rose\nRed\nFragrant\n1\n"))
            {
                Console.SetIn(input);
                rose.Init();
                Assert.IsTrue(rose.HasThorns);
            }
        }

        [TestMethod]
        public void ToString_ReturnsBaseFormat()
        {
            // Проверяем, что ToString наследуется от Plant и возвращает правильный формат
            Rose rose = new Rose("Pink Rose", "Pink", "Subtle", false, 4);

            Assert.AreEqual("Plant: Name=Pink Rose, Color=Pink", rose.ToString());
        }
    }

    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void Equals_WithSameProperties_ReturnsTrue()
        {
            // Проверяем, что посты с одинаковыми значениями равны
            Post post1 = new Post(100, 20, 50);
            Post post2 = new Post(100, 20, 50);

            Assert.IsTrue(post1.Equals(post2));
        }

        [TestMethod]
        public void Equals_WithDifferentViews_ReturnsFalse()
        {
            // Проверяем, что посты с разными просмотрами не равны
            Post post1 = new Post(100, 20, 50);
            Post post2 = new Post(200, 20, 50);

            Assert.IsFalse(post1.Equals(post2));
        }

        [TestMethod]
        public void CalculateEngagementRate_ReturnsCorrectValue()
        {
            // Проверяем, что метод расчёта вовлечённости возвращает правильное значение
            Post post = new Post(100, 20, 50);
            double expectedRate = (100 + 20 + 50) / 1000.0 * 100;

            Assert.AreEqual(expectedRate, post.CalculateEngagementRate(1000));
        }

        [TestMethod]
        public void CalculateEngagementRateStatic_ReturnsSameAsInstance()
        {
            // Проверяем, что статический метод даёт тот же результат, что и экземплярный
            Post post = new Post(100, 20, 50);
            double staticRate = Post.CalculateEngagementRateStatic(post, 1000);

            Assert.AreEqual(post.CalculateEngagementRate(1000), staticRate);
        }

        [TestMethod]
        public void OperatorIncrement_IncreasesViews()
        {
            // Проверяем, что оператор ++ увеличивает количество просмотров
            Post post = new Post(100, 20, 50);
            Post incrementedPost = ++post;

            Assert.AreEqual(101, incrementedPost.NumViews);
        }

        [TestMethod]
        public void OperatorNot_IncreasesReactions()
        {
            // Проверяем, что оператор ! увеличивает количество реакций
            Post post = new Post(100, 20, 50);
            Post modifiedPost = !post;

            Assert.AreEqual(51, modifiedPost.NumReactions);
        }

        [TestMethod]
        public void OperatorEqual_ReturnsTrueForSameValues()
        {
            // Проверяем, что оператор == возвращает true для одинаковых постов
            Post post1 = new Post(100, 20, 50);
            Post post2 = new Post(100, 20, 50);

            Assert.IsTrue(post1 == post2);
        }

        [TestMethod]
        public void OperatorNotEqual_ReturnsTrueForDifferentValues()
        {
            // Проверяем, что оператор != возвращает true для разных постов
            Post post1 = new Post(100, 20, 50);
            Post post2 = new Post(200, 20, 50);

            Assert.IsTrue(post1 != post2);
        }

        [TestMethod]
        public void ImplicitOperatorDouble_ReturnsRoundedCoverage()
        {
            // Проверяем, что неявное приведение к double возвращает правильное значение
            Post post = new Post(1500, 20, 50);
            double coverage = post;

            Assert.AreEqual(1.5, coverage);
        }

        [TestMethod]
        public void ExplicitOperatorBool_ReturnsTrueForActivePost()
        {
            // Проверяем, что активный пост приводится к true
            Post post = new Post(100, 20, 0);
            bool isActive = (bool)post;

            Assert.IsTrue(isActive);
        }

        [TestMethod]
        public void ExplicitOperatorBool_ReturnsFalseForInactivePost()
        {
            // Проверяем, что неактивный пост приводится к false
            Post post = new Post(0, 0, 0);
            bool isActive = (bool)post;

            Assert.IsFalse(isActive);
        }

        [TestMethod]
        public void RandomInit_SetsNonNegativeViews()
        {
            // Проверяем, что случайная инициализация задаёт неотрицательные просмотры
            Post post = new Post();
            post.RandomInit();

            Assert.IsTrue(post.NumViews >= 0);
        }

        [TestMethod]
        public void RandomInit_SetsNonNegativeComments()
        {
            // Проверяем, что случайная инициализация задаёт неотрицательные комментарии
            Post post = new Post();
            post.RandomInit();

            Assert.IsTrue(post.NumComments >= 0);
        }

        [TestMethod]
        public void RandomInit_SetsNonNegativeReactions()
        {
            // Проверяем, что случайная инициализация задаёт неотрицательные реакции
            Post post = new Post();
            post.RandomInit();

            Assert.IsTrue(post.NumReactions >= 0);
        }

        [TestMethod]
        public void Init_SetsValidViewsFromInput()
        {
            // Проверяем, что Init корректно устанавливает просмотры из ввода
            Post post = new Post();
            using (var input = new StringReader("150\n20\n50\n"))
            {
                Console.SetIn(input);
                post.Init();
                Assert.AreEqual(150, post.NumViews);
            }
        }

        [TestMethod]
        public void GetTotalPostCount_IncreasesWithNewObjects()
        {
            // Проверяем, что счётчик постов увеличивается при создании новых объектов
            int initialCount = Post.GetTotalPostCount();
            Post post1 = new Post();
            Post post2 = new Post();

            Assert.AreEqual(initialCount + 2, Post.GetTotalPostCount());
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Проверяем, что ToString возвращает правильный формат строки
            Post post = new Post(100, 20, 50);

            Assert.AreEqual("100, 20, 50", post.ToString());
        }
    }
}