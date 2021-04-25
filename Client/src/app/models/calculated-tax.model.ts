import { CalculatedTaxBracket } from "./calculated-tax-bracket.model"
import { Frequency } from "./enums"

export class CalculatedTaxViewModel
{
     tax: number
     formula: Frequency
     calculatedBrackets: [CalculatedTaxBracket]
}