using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProductsManager : MonoBehaviour 
{
	private static ProductsManager instance;

	public List<ItemSettings> productsList = new List<ItemSettings>();
	private Dictionary<string, ItemSettings> productsDictionary = new Dictionary<string, ItemSettings>();

	public static ProductsManager Instance
	{
		get{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(ProductsManager)) as ProductsManager;

				if(instance == null)
					instance = new GameObject("ProductsManager").AddComponent<ProductsManager>();
			}

			return instance;
		}
	}

	public void AddProduct(ItemSettings pItem)
	{
		if(productsDictionary == null)
			productsDictionary = new Dictionary<string, ItemSettings>();

		if(!productsDictionary.ContainsKey(pItem.productID))
		{
			productsDictionary.Add(pItem.productID, pItem);
			productsList.Add(pItem);
#if UNITY_EDITOR
			Debug.Log("ProductsManager : Added : " + pItem.productID);
#endif
		}
		else
		{
#if UNITY_EDITOR
			Debug.LogError("ProductsManager : Already Contains : " + pItem.productID);
#endif
		}
	}

	public ItemSettings GetProduct(string pProductID)
	{
		if(productsDictionary.ContainsKey(pProductID))
		{
			return productsDictionary[pProductID];
		}
		else
		{
#if UNITY_EDITOR
			Debug.LogError("Product Manager : Product: " + pProductID + " not found!");
#endif
			return null;
		}
	}
}