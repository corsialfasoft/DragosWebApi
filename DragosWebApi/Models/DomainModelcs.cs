using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DragosWebApi.Models {
	interface IDomainModel{
		Prodotto Search(int id);
		List<Prodotto> Search(string des);
		void SpedisciOrdine(List<Prodotto> prodotti);
        void Del(int id);
        void Add(Prodotto nuovo);

	}

	public class Prodotto {
		public int Id{ get;set;}
		public string Descrizione{ get;set;}
		public int Giacenza{ get;set;}
		public int QtaOrdine{ get;set;}
        public override bool Equals(object obj) {
            return this.Id==((Prodotto)obj).Id;
        }
    }

	public class DomainModel : IDomainModel {
		RICHIESTEEntities db = null;
		public Prodotto Search(int id) {
			using(db= new RICHIESTEEntities()){
				ProdottiSet prodotto = db.ProdottiSet.Find(id);
				if(prodotto!=null){
					return new Prodotto{ Id=prodotto.id,Descrizione=prodotto.descrizione,Giacenza=prodotto.giacenza};
				}
				return null;
			}
		}

		public List<Prodotto> Search(string des) {
			using (db = new RICHIESTEEntities()) {
				var query = from pro in db.ProdottiSet
							where pro.descrizione.Contains(des)
							select pro;
				List<Prodotto> prodotti = new List<Prodotto>();
 				foreach(ProdottiSet prodotto in query)
					prodotti.Add(new Prodotto { Id = prodotto.id, Descrizione = prodotto.descrizione, Giacenza = prodotto.giacenza });
				return prodotti;
			}
		}

		public void SpedisciOrdine(List<Prodotto> prodotti) {
			using (db = new RICHIESTEEntities()) {
				OrdiniSet richiesta = new OrdiniSet{dataOrdine=DateTime.Now};
				db.OrdiniSet.Add(richiesta);
				foreach(Prodotto prodotto in prodotti){
					ProdottiSet ps = db.ProdottiSet.Find(prodotto.Id);
					if(ps!=null){ 
						OridiniProdotti rp =new OridiniProdotti{OrdiniSet = richiesta, ProdottiSet = ps, quantita= prodotto.QtaOrdine};
						db.OridiniProdotti.Add(rp);
						db.SaveChanges();
					}
				}

			}
		}
        public void Del(int id){ 
            using (db = new RICHIESTEEntities()) {
			    ProdottiSet elimina = db.ProdottiSet.Find(id);
			    db.ProdottiSet.Remove(elimina);
                db.SaveChanges();
			    }   
        }   
        public void Add(Prodotto nuovo){
            using (db = new RICHIESTEEntities()) {
			    ProdottiSet aggiungi = new ProdottiSet{descrizione=nuovo.Descrizione, giacenza=nuovo.Giacenza};
                db.ProdottiSet.Add(aggiungi);
                db.SaveChanges();
			    }   
            }
	}
}