using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SeloInfos), true), CanEditMultipleObjects]
public class SeloInfoEditor : Editor
{
	private SeloInfos myTarget;

	void OnEnable()
	{
		myTarget = target as SeloInfos;
	}

	public override void OnInspectorGUI ()
	{
		myTarget.category = (LABEL_CATEGORY)EditorGUILayout.EnumPopup("CATEGORIA: ", myTarget.category);

		switch(myTarget.category)
		{
		case LABEL_CATEGORY.ATRIBUTO:
			myTarget.atributo = (ATRIBUTOS)EditorGUILayout.EnumPopup("Atributo: ", myTarget.atributo);
			break;

		case LABEL_CATEGORY.CABECA:
			myTarget.cabeca = (CABECAS)EditorGUILayout.EnumPopup("Cabeca: ", myTarget.cabeca);
			break;

		case LABEL_CATEGORY.TEXTURA:
			myTarget.textura = (TIPO_CERDA)EditorGUILayout.EnumPopup("Textura: ", myTarget.textura);
			break;

		case LABEL_CATEGORY.VALORIZACAO:
			myTarget.valorizacao = (VALORIZACAO)EditorGUILayout.EnumPopup("Valorizacao: ", myTarget.valorizacao);
			break;

		case LABEL_CATEGORY.CLASSIFICACAO_ETARIA:
			myTarget.classificacaoEtaria = (CLASSIFICAO_ETARIA)EditorGUILayout.EnumPopup("Classificacao Etaria: ", myTarget.classificacaoEtaria);
			break;

		case LABEL_CATEGORY.OUTROS:
			myTarget.outros = (OUTROS)EditorGUILayout.EnumPopup("Outros: ", myTarget.outros);
			break;

		case LABEL_CATEGORY.USO_PRODUTOS:
			myTarget.usoProdutos = (USO_PRODUTOS)EditorGUILayout.EnumPopup("Uso Produtos: ", myTarget.usoProdutos);
			break;

		case LABEL_CATEGORY.PUBLICO:
			myTarget.publico = (PUBLICO)EditorGUILayout.EnumPopup("Publico: ", myTarget.publico);
			break;
		}

		base.OnInspectorGUI();
		EditorUtility.SetDirty(myTarget);
	}
}
