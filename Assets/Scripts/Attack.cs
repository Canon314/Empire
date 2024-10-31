using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public ColorHandler firstSelectedCountry;
    public ColorHandler secondSelectedCountry;
    public bool isAttacking = false;

    public void PerformAttack()
    {
        int firstArmyValue = firstSelectedCountry.GetArmyValue();
        int secondArmyValue = secondSelectedCountry.GetArmyValue();
        Debug.Log("Got values");

        if (firstArmyValue > secondArmyValue)
        {
            AttackCountry(firstSelectedCountry, secondSelectedCountry);
        }
        else if (secondArmyValue > firstArmyValue)
        {
            AttackCountry(secondSelectedCountry, firstSelectedCountry);
        }
        else
        {
            Debug.Log("Army values are equal. No attack performed.");
        }

        // Reset selections
        firstSelectedCountry = null;
        secondSelectedCountry = null;
    }

    private void AttackCountry(ColorHandler attacker, ColorHandler defender)
    {
        int attackerArmies = attacker.GetArmyValue();
        int defenderArmies = defender.GetArmyValue();

        // Update attacker's armies
        attacker.SetArmyValue(attackerArmies - defenderArmies);

        // Update defender's color and armies
        defender.CurrentColor = Color.white;
        defender.SetArmyValue(0);

        Debug.Log($"{attacker.gameObject.name} attacked {defender.gameObject.name}");
    }
}