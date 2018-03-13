using System;
using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int AxeAttack = 1;
    private const int AxeDurability = 10;
    private const int DummyHealth = 1;
    private const int DummyExperience = 1;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestUnit()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        // Act
        this.axe.Attack(this.dummy);

        // Assert
        Assert.AreEqual(0, this.dummy.Health, "Dummy doesn't lose health after attack!");
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        // Act
        this.axe.Attack(this.dummy);

        // Assert
        Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy), "Dead dummy doesn't throw exception if attacked!");

    }

    [Test]
    public void DeadDummyCanGiveXp()
    {
        // Act
        this.axe.Attack(this.dummy);

        // Assert
        Assert.AreEqual(1, this.dummy.GiveExperience(), "Dead Dummy can't give Xp!");
    }

    [Test]
    public void AliveDummyCanNotGiveXp()
    {
        // Assert
        Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience(),
            "Dead dummy doesn't throw exception if attacked!");
    }
}
