using _07MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] soldierData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string soldierKind = soldierData[0];
                int id = int.Parse(soldierData[1]);
                string firstName = soldierData[2];
                string lastName = soldierData[3];
                switch (soldierKind)
                {
                    case "Private":
                        decimal privateSalary = decimal.Parse(soldierData[4]);
                        Private @private = new Private(id, firstName, lastName, privateSalary);
                        soldiers.Add(@private);
                        break;
                    case "LieutenantGeneral":
                        decimal lieutenantGeneralSalary = decimal.Parse(soldierData[4]);
                        LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, lieutenantGeneralSalary);
                        for (int i = 5; i < soldierData.Length; i++)
                        {
                            int privateId = int.Parse(soldierData[i]);

                            ISoldier soldier = soldiers.FirstOrDefault(s => s.Id == privateId);
                            Private private1 = (Private)soldier;
                            lieutenantGeneral.Privates.Add(private1);
                        }

                        soldiers.Add(lieutenantGeneral);
                        break;
                    case "Engineer":
                        decimal engineerSalary = decimal.Parse(soldierData[4]);
                        try
                        {
                            string corps = soldierData[5];
                            Engineer engineer = new Engineer(id, firstName, lastName, engineerSalary, corps);
                            for (int i = 6; i < soldierData.Length; i += 2)
                            {
                                string partName = soldierData[i];
                                int hoursWorked = int.Parse(soldierData[i + 1]);
                                Repair repair = new Repair(partName, hoursWorked);
                                engineer.Repairs.Add(repair);
                            }

                            soldiers.Add(engineer);
                        }
                        catch (ArgumentException)
                        {

                        }

                        break;
                    case "Commando":
                        decimal commandoSalary = decimal.Parse(soldierData[4]);
                        try
                        {
                            string corps = soldierData[5];
                            Commando commando = new Commando(id, firstName, lastName, commandoSalary, corps);
                            for (int i = 6; i < soldierData.Length; i += 2)
                            {
                                string codeName = soldierData[i];
                                string state = soldierData[i + 1];
                                try
                                {
                                    Mission mission = new Mission(codeName, state);
                                    commando.Missions.Add(mission);
                                }
                                catch (ArgumentException)
                                {

                                }
                            }

                            soldiers.Add(commando);
                        }
                        catch (ArgumentException)
                        {

                        }

                        break;
                    case "Spy":
                        int codeNumber = int.Parse(soldierData[4]);
                        Spy spy = new Spy(id, firstName, lastName, codeNumber);
                        soldiers.Add(spy);
                        break;
                }
            }

            soldiers.ForEach(s => Console.WriteLine(s));
        }
    }   
}