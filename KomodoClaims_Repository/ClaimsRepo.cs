using KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Classes
{
    public class ClaimRepo
    {
        private Queue<Claims> _claims = new Queue<Claims>();

        //CRUD

        //Create

        public void AddClaimToRepo(Claims claim)
        {
            _claims.Enqueue(claim);

        }

        //Read

        public void ShowClaims()
        {
            Console.WriteLine("ClaimID    Type                Description        Amount    DateOfIncident    DateOfClaim    IsValid");
            foreach (Claims item in _claims)
            {
                Console.WriteLine($"{item.ClaimID}          {item.ClaimType}                {item.Description}      {item.ClaimAmount}      {String.Format("{0:M/d/yyyy}", item.DateOfIncident)}        {String.Format("{0:M/d/yyyy}", item.DateOfClaim)}       {item.IsValid}");
            }
            //Console.WriteLine("Press any key to return to the menu");
            //Console.ReadKey();
        }

        //Delete

        public string ShowClaim(Claims item)
        {
            return $"{item.ClaimID}          {item.ClaimType}                {item.Description}      {item.ClaimAmount}      {String.Format("{0:M/d/yyyy}", item.DateOfIncident)}        {String.Format("{0:M/d/yyyy}", item.DateOfClaim)}       {item.IsValid}";
        }

        public void GetNextClaim()
        {
            Console.WriteLine("Getting next claim...\n");
            Console.WriteLine(ShowClaim(_claims.Peek()));
        }
        public void HandleClaim()
        {
            _claims.Dequeue();
        }

        /*
        public Claims GetClaimByID(int id)
        {
            foreach (Claims claim in _claims)
            {
                if (claim.ClaimID == id)
                {
                    return claim;
                }
            }
            return null;
        }
        */
    }
}
