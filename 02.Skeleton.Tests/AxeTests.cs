using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttack = 1;
    private const int AxeDurability = 1;
    private const int DummyHealth = 10;
    private const int DummyExperience = 10;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestUnit()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void AxeLosesDurabilyAfterAttack()
    {
        // Act
        this.axe.Attack(this.dummy);

        // Assert
        Assert.AreEqual(0, this.axe.DurabilityPoints, "Axe doesn't lose durability after attack!");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        // Act
        this.axe.Attack(this.dummy);

        // Assert
        Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy), "Broken axe can attack!");
    }
}
