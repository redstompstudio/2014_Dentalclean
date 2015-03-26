using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum SELOS_CERDAS
{
	MACIAS,
	NORMAIS,
	SEILA,
}

public enum SELOS_COR
{
	BRANCA,
	AZUL,
	VERMELHA,
}

[System.Serializable]
public class ProductData
{
	public string productName;
	public Sprite productImage;
	public Sprite productLogo;
	public string productText;

	public SELOS_COR[] selosCor;
	public SELOS_CERDAS[] selosCerdas;
}

public class ProductsDataBase : MonoBehaviour 
{
	private static ProductsDataBase instance;

	public List<ProductData> productsData = new List<ProductData>();

	public static ProductsDataBase Instance
	{
		get{
			if(instance == null)
				instance = FindObjectOfType(typeof(ProductsDataBase)) as ProductsDataBase;

			return instance;
		}
	}
}
