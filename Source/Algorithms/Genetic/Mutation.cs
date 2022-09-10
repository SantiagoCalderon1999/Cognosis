using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognosis.Algorithms.Genetic
{
    class Mutation
    {
        /// <summary>
        /// Mutates a given list of children
        /// </summary>
        /// <param name="mutationPercentage">Percentage of children that are going to be mutated </param>
        /// <param name="mutationMaxDistance">Maximum distance for mutation</param>
        /// <param name="numberOfIndividuals">Number of total individuals</param>
        /// <param name="childrenToMutate">Children that are going to be mutated</param>
        /// <returns>List of Children mutated</returns>
        public List<List<List<double>>> Mutate(int mutationPercentage, int mutationMaxDistance, int numberOfIndividuals, List<List<List<double>>> childrenToMutate)
        {
            int numOfElementsPerChild = childrenToMutate[0].Count;
            Random rnd = new Random();
            // Mutates randomly 
            for (int i = 0; i < (int)(mutationPercentage * numberOfIndividuals / 100); i++)
            {
                int indiceciudadMut = rnd.Next(0, numberOfIndividuals);
                int indiceMut = rnd.Next(0, numOfElementsPerChild - mutationMaxDistance);
                List<double> aux = childrenToMutate[indiceciudadMut][indiceMut];
                childrenToMutate[indiceciudadMut][indiceMut] = childrenToMutate[indiceciudadMut][indiceMut + mutationMaxDistance];
                childrenToMutate[indiceciudadMut][indiceMut + mutationMaxDistance] = aux;   
            }
            return childrenToMutate;
        }
    }
}
