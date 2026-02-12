using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace SombrasDelUmbral.Editor
{
    /// <summary>
    /// Herramienta para crear las escenas base del proyecto
    /// Basado en ROADMAP.md - Tarea 1.1.1 línea 54
    /// </summary>
    public class SceneSetupTool : EditorWindow
    {
        [MenuItem("Sombras del Umbral/Setup/Create Base Scenes")]
        public static void CreateBaseScenes()
        {
            if (EditorUtility.DisplayDialog(
                "Crear Escenas Base",
                "Esta herramienta creará las siguientes escenas:\n\n" +
                "1. MainMenu - Menú principal del juego\n" +
                "2. GameScene - Escena principal de gameplay\n\n" +
                "Las escenas se crearán en Assets/_Project/Scenes/\n\n" +
                "¿Continuar?",
                "Sí, Crear Escenas",
                "Cancelar"))
            {
                CreateScenes();
            }
        }

        private static void CreateScenes()
        {
            try
            {
                // Crear carpeta de escenas si no existe
                string scenesPath = "Assets/_Project/Scenes";
                if (!AssetDatabase.IsValidFolder(scenesPath))
                {
                    AssetDatabase.CreateFolder("Assets/_Project", "Scenes");
                    Debug.Log($"✓ Carpeta creada: {scenesPath}");
                }

                EditorUtility.DisplayProgressBar("Creando Escenas", "Creando MainMenu...", 0.3f);
                CreateMainMenuScene(scenesPath);

                EditorUtility.DisplayProgressBar("Creando Escenas", "Creando GameScene...", 0.6f);
                CreateGameScene(scenesPath);

                EditorUtility.DisplayProgressBar("Creando Escenas", "Configurando Build Settings...", 0.9f);
                AddScenesToBuildSettings(scenesPath);

                EditorUtility.ClearProgressBar();

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                EditorUtility.DisplayDialog(
                    "✅ Escenas Creadas",
                    "Las escenas base se han creado correctamente:\n\n" +
                    "✓ MainMenu.unity\n" +
                    "✓ GameScene.unity\n\n" +
                    "Ambas escenas se han añadido a Build Settings.\n" +
                    "MainMenu es la escena de inicio (índice 0).",
                    "Entendido"
                );

                Debug.Log("✅ Escenas base creadas exitosamente!");

                // Abrir MainMenu
                EditorSceneManager.OpenScene($"{scenesPath}/MainMenu.unity");
            }
            catch (System.Exception e)
            {
                EditorUtility.ClearProgressBar();
                EditorUtility.DisplayDialog(
                    "❌ Error",
                    $"Ocurrió un error al crear las escenas:\n\n{e.Message}",
                    "OK"
                );
                Debug.LogError($"Error creando escenas: {e}");
            }
        }

        private static void CreateMainMenuScene(string scenesPath)
        {
            // Crear nueva escena
            Scene mainMenuScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            mainMenuScene.name = "MainMenu";

            // Configurar Main Camera
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                mainCamera.clearFlags = CameraClearFlags.SolidColor;
                mainCamera.backgroundColor = new Color(0.1f, 0.1f, 0.15f); // Azul oscuro
                mainCamera.orthographic = true;
                mainCamera.orthographicSize = 5f;
                mainCamera.transform.position = new Vector3(0, 0, -10);
            }

            // Crear Canvas para UI
            GameObject canvasGO = new GameObject("Canvas");
            Canvas canvas = canvasGO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasGO.AddComponent<UnityEngine.UI.CanvasScaler>();
            canvasGO.AddComponent<UnityEngine.UI.GraphicRaycaster>();

            // Configurar CanvasScaler para UI responsive
            UnityEngine.UI.CanvasScaler scaler = canvasGO.GetComponent<UnityEngine.UI.CanvasScaler>();
            scaler.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            scaler.screenMatchMode = UnityEngine.UI.CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.matchWidthOrHeight = 0.5f;

            // Crear EventSystem
            GameObject eventSystemGO = new GameObject("EventSystem");
            eventSystemGO.AddComponent<UnityEngine.EventSystems.EventSystem>();
            eventSystemGO.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();

            // Crear placeholder de título
            GameObject titleGO = new GameObject("Title");
            titleGO.transform.SetParent(canvasGO.transform, false);
            UnityEngine.UI.Text titleText = titleGO.AddComponent<UnityEngine.UI.Text>();
            titleText.text = "SOMBRAS DEL UMBRAL";
            titleText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            titleText.fontSize = 72;
            titleText.alignment = TextAnchor.MiddleCenter;
            titleText.color = Color.white;
            
            RectTransform titleRect = titleGO.GetComponent<RectTransform>();
            titleRect.anchorMin = new Vector2(0.5f, 0.7f);
            titleRect.anchorMax = new Vector2(0.5f, 0.7f);
            titleRect.sizeDelta = new Vector2(800, 100);

            // Crear placeholder de botón
            GameObject buttonGO = new GameObject("PlayButton");
            buttonGO.transform.SetParent(canvasGO.transform, false);
            UnityEngine.UI.Button button = buttonGO.AddComponent<UnityEngine.UI.Button>();
            UnityEngine.UI.Image buttonImage = buttonGO.AddComponent<UnityEngine.UI.Image>();
            buttonImage.color = new Color(0.2f, 0.6f, 0.8f);
            
            RectTransform buttonRect = buttonGO.GetComponent<RectTransform>();
            buttonRect.anchorMin = new Vector2(0.5f, 0.4f);
            buttonRect.anchorMax = new Vector2(0.5f, 0.4f);
            buttonRect.sizeDelta = new Vector2(300, 80);

            // Texto del botón
            GameObject buttonTextGO = new GameObject("Text");
            buttonTextGO.transform.SetParent(buttonGO.transform, false);
            UnityEngine.UI.Text buttonText = buttonTextGO.AddComponent<UnityEngine.UI.Text>();
            buttonText.text = "JUGAR";
            buttonText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            buttonText.fontSize = 36;
            buttonText.alignment = TextAnchor.MiddleCenter;
            buttonText.color = Color.white;
            
            RectTransform buttonTextRect = buttonTextGO.GetComponent<RectTransform>();
            buttonTextRect.anchorMin = Vector2.zero;
            buttonTextRect.anchorMax = Vector2.one;
            buttonTextRect.sizeDelta = Vector2.zero;

            // Guardar escena
            EditorSceneManager.SaveScene(mainMenuScene, $"{scenesPath}/MainMenu.unity");
            Debug.Log("✓ MainMenu.unity creada");
        }

        private static void CreateGameScene(string scenesPath)
        {
            // Crear nueva escena
            Scene gameScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            gameScene.name = "GameScene";

            // Configurar Main Camera para 2D
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                mainCamera.clearFlags = CameraClearFlags.SolidColor;
                mainCamera.backgroundColor = new Color(0.15f, 0.15f, 0.2f); // Gris azulado oscuro
                mainCamera.orthographic = true;
                mainCamera.orthographicSize = 5f;
                mainCamera.transform.position = new Vector3(0, 0, -10);
                
                // Añadir tag MainCamera si no lo tiene
                if (!mainCamera.CompareTag("MainCamera"))
                {
                    mainCamera.tag = "MainCamera";
                }
            }

            // Crear Grid para Tilemaps
            GameObject gridGO = new GameObject("Grid");
            Grid grid = gridGO.AddComponent<Grid>();
            grid.cellSize = new Vector3(1, 1, 0);

            // Crear Tilemap para Ground
            GameObject groundTilemapGO = new GameObject("Ground");
            groundTilemapGO.transform.SetParent(gridGO.transform);
            groundTilemapGO.layer = LayerMask.NameToLayer("Ground");
            var groundTilemap = groundTilemapGO.AddComponent<UnityEngine.Tilemaps.Tilemap>();
            var groundRenderer = groundTilemapGO.AddComponent<UnityEngine.Tilemaps.TilemapRenderer>();
            groundRenderer.sortingLayerName = "Default";
            groundRenderer.sortingOrder = 0;

            // Añadir Tilemap Collider 2D
            var groundCollider = groundTilemapGO.AddComponent<UnityEngine.Tilemaps.TilemapCollider2D>();

            // Crear Tilemap para Walls
            GameObject wallsTilemapGO = new GameObject("Walls");
            wallsTilemapGO.transform.SetParent(gridGO.transform);
            wallsTilemapGO.layer = LayerMask.NameToLayer("Wall");
            var wallsTilemap = wallsTilemapGO.AddComponent<UnityEngine.Tilemaps.Tilemap>();
            var wallsRenderer = wallsTilemapGO.AddComponent<UnityEngine.Tilemaps.TilemapRenderer>();
            wallsRenderer.sortingLayerName = "Default";
            wallsRenderer.sortingOrder = 1;

            // Añadir Tilemap Collider 2D
            var wallsCollider = wallsTilemapGO.AddComponent<UnityEngine.Tilemaps.TilemapCollider2D>();

            // Crear GameObject para Player (placeholder)
            GameObject playerGO = new GameObject("Player");
            playerGO.layer = LayerMask.NameToLayer("Player");
            playerGO.transform.position = new Vector3(0, 1, 0);
            playerGO.tag = "Player";
            
            // Añadir SpriteRenderer placeholder
            SpriteRenderer playerSprite = playerGO.AddComponent<SpriteRenderer>();
            playerSprite.color = Color.cyan;
            playerSprite.sortingOrder = 10;
            
            // Crear sprite cuadrado simple
            Texture2D tex = new Texture2D(1, 1);
            tex.SetPixel(0, 0, Color.white);
            tex.Apply();
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1);
            playerSprite.sprite = sprite;

            // Añadir Rigidbody2D
            Rigidbody2D rb = playerGO.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;
            rb.freezeRotation = true;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

            // Añadir CapsuleCollider2D
            CapsuleCollider2D col = playerGO.AddComponent<CapsuleCollider2D>();
            col.size = new Vector2(0.8f, 1.8f);
            col.direction = CapsuleDirection2D.Vertical;

            // Crear GameObject para Managers
            GameObject managersGO = new GameObject("--- MANAGERS ---");

            // Guardar escena
            EditorSceneManager.SaveScene(gameScene, $"{scenesPath}/GameScene.unity");
            Debug.Log("✓ GameScene.unity creada");
        }

        private static void AddScenesToBuildSettings(string scenesPath)
        {
            // Obtener escenas actuales en Build Settings
            var scenes = new System.Collections.Generic.List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

            // Añadir MainMenu (índice 0)
            string mainMenuPath = $"{scenesPath}/MainMenu.unity";
            if (!SceneExistsInBuildSettings(mainMenuPath))
            {
                scenes.Insert(0, new EditorBuildSettingsScene(mainMenuPath, true));
                Debug.Log("✓ MainMenu añadida a Build Settings (índice 0)");
            }

            // Añadir GameScene (índice 1)
            string gameScenePath = $"{scenesPath}/GameScene.unity";
            if (!SceneExistsInBuildSettings(gameScenePath))
            {
                scenes.Add(new EditorBuildSettingsScene(gameScenePath, true));
                Debug.Log("✓ GameScene añadida a Build Settings (índice 1)");
            }

            EditorBuildSettings.scenes = scenes.ToArray();
        }

        private static bool SceneExistsInBuildSettings(string scenePath)
        {
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (scene.path == scenePath)
                    return true;
            }
            return false;
        }
    }
}
