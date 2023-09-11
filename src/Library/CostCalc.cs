/*
En este caso, se aplica el principio SRP de SOLID, el cual consiste en crear una clase
que será utilizada exclusivamente para calcular los costos de la producción de la receta.
*/
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID{
    public class CostCalc{
        public double CalcCost(Recipe recipe){
            double IngredientCost = CalcIngredientCost(recipe);
            double EquipmentCost = CalcEquipmentCost(recipe);

            return IngredientCost + EquipmentCost;
        }
        private double CalcIngredientCost(Recipe recipe){
            double IngredientCost = 0;
            foreach(Step step in recipe.Steps){
                IngredientCost += step.Input.UnitCost * step.Quantity;
            }
            return IngredientCost;
        }
        private double CalcEquipmentCost(Recipe recipe){
            double EquipmentCost = 0;
            foreach(Step step in recipe.Steps){
                EquipmentCost += (step.Time / 60.0) * step.Equipment.HourlyCost;
            }
            return EquipmentCost;
        }
    }
}