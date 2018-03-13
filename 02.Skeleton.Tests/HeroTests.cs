using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private const string HeroName = "Pesho";

    private const int AxeAttack = 10;
    private const int AxeDurability = 10;
    private const int DummyHealth = 1;
    private const int DummyExperience = 1;

    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDies()
    {
        // Arrange
        IWeapon axe = new Axe(AxeAttack, AxeDurability);
        ITarget dummy = new Dummy(DummyHealth, DummyExperience);
        Hero hero = new Hero(HeroName, axe);

        // Act
        hero.Attack(dummy);

        // Assert
        Assert.AreEqual(1, hero.Experience, "Hero doesn't get experience after attack when target dies!");
    }
}
