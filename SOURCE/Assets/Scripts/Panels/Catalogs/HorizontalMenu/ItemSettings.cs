using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum TIPO_CERDA
{
	CORTE_RETO,
	POWER_TIP,
	CORTE_3D,
	CERDAS_V,
	TUFO_FINO,
	TUFO_GROSSO,
	PONTAS_FINAS,
	PONTAS_ARREDONDADAS,
	VERSAO_CILINDRICA,
	VERSAO_CONICA,
	CERDAS_CIRCULARES,
	CERDA_DURA,
	CERDA_MEDIA,
	CERDA_MACIA,
	CERDA_EXTRA_MACIA,
	CERDA_ULTRA_MACIA,
	CERDA_DUPLA_ACAO,
}

public enum ATRIBUTOS
{
	CERDA_VENTOSA,
	ESTOJO_PORTATIL,
	EXCLUSIVO_LIMPADOR_LINGUA,
	ALCANCE_PROFUNDO,
	INTERDENTAL_EFICAZ,
	AREAS_DIFICEIS,
	PROTESE_APARELHOS,
	DOIS_ANGULOS,
	ANGULO_ABERTO,
	ANGULO_FECHADO,
	CABO_3D,
	CABO_EMBORRACHADO,
	CABO_ESTENDIDO,
	ARAME_REVESTIDO,
	LIMPADOR_LINGUA_EMBORRACHADO,
	LIMPADOR_LINGUA,
	MASSAGEADOR_GENGIVA,
}

public enum CABECAS
{
	QUADRADA,
	OVAL,
	DIAMANTE,
	T_27,
	T_30,
	T_32,
	T_35,
	T_37,
	T_40,
}

public enum VALORIZACAO
{
	PROTETOR_CERDA,
	PROTETOR_CERDA_VENTOSA,
	CABECA_FULL,
	MAIS_CERDAS,
	LIMPA_MAIS,
	MAIS_FINO_MAIS_LONGO,
	PROTECAO_TOTAL_DENTE_GENGIVA,
}

public enum CLASSIFICAO_ETARIA
{
	CRIANCAS_MAIS_2_ANOS,
	CRIANCAS_4_9,
	JOVENS_MAIS_16,
	CRIANCAS_MAIS_3,
}


public enum OUTROS
{
	EXTRA_FINA_4MM,
	FINA_5MM,
	MEDIA_6MM,
	_4_UNIDADES,
	PRODUZIDO_BR,
	PACK_PROMOCIONAL,
}

public enum USO_PRODUTOS
{
	ANTISSEPTICO,
	CERA_ORTODONTICA,
	ESCOVA,
	RASPADOR_LINGUA,
	FIO_DENTAL,
	ORIENTACAO_DENTISTA
}

public enum PUBLICO
{
	IDOSOS,
	GESTANTES,
	LACTANTES,
	BEBES,
	CRIANCAS,
	DIABETICOS,
	ONCOLOGICOS,
}

public class ItemSettings : MonoBehaviour 
{
	[HideInInspector]
	public string productID;
	[HideInInspector]
	public Sprite catalogImage;
	public Sprite logoImage;

	[HideInInspector]
	public string itemInformationText;

	public TIPO_CERDA[] texturas;
	public ATRIBUTOS[] atributos;
	public CABECAS[] cabecas;
	public PUBLICO[] publico;
	public OUTROS[] outros;
	public VALORIZACAO[] valorizacao;
	public CLASSIFICAO_ETARIA[] classificaoEtaria;
	public USO_PRODUTOS[] usoProdutos;

	private Button button;

	void Awake()
	{
		if(button == null)
			button = GetComponent<Button>();

		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(OnClickButton);

		if(string.IsNullOrEmpty(productID))
			productID = this.name;
			
		ProductsManager.Instance.AddProduct(this);

//		if(catalogImage == null)
		catalogImage = GetComponent<UnityEngine.UI.Image>().sprite;
	}

	public void OnClickButton()
	{
#if UNITY_EDITOR
		Debug.Log("On Click Item : " + gameObject.name);
#endif
		ItemDetailsPanel.instance.Show(this);
	}
}