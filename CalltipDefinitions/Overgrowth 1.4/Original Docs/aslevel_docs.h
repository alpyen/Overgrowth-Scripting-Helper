//Mandatory functions in script
void Init(string level_name)

//Optional functions in script
void Update(int is_paused)
void Update()
void HotspotExit(string event, MovementObject @mo)
void HotspotEnter(string event, MovementObject @mo)
void ReceiveMessage(string message)
void DrawGUI()
void DrawGUI2()
void DrawGUI3()
bool HasFocus()
bool DialogueCameraControl()
void SaveHistoryState(SavedChunk@ chunk)
void ReadChunk(SavedChunk@ chunk)
void SetWindowDimensions(int width, int height)
void IncomingTCPData(uint socket, array<uint8>@ data)
void PreScriptReload()
void PostScriptReload()
void Menu()

//Interface
    void push_back(const T&in);
    uint size() const;
void StartStopwatch();
uint64 StopAndReportStopwatch();
void EnterTelemetryZone(const string& in name);
void LeaveTelemetryZone();
uint UINT32MAX;
float fpFromIEEE(uint);
uint fpToIEEE(float);
double fpFromIEEE(uint64);
uint64 fpToIEEE(double);
float min(float,float);
float max(float,float);
int min(int,int);
int max(int,int);
float mix(float a,float b,float amount);
float cos(float);
float sin(float);
float tan(float);
float acos(float);
float asin(float);
float atan(float);
float atan2(float,float);
float log(float);
float log10(float);
float pow(float val, float exponent);
float sqrt(float);
int rand();
float RangedRandomFloat(float min, float max);
float ceil(float);
float abs(float);
float floor(float);
class vec2 {
    float x;
    float y;
    void f();
    void f(const vec2 &in);
    void f(float, float);
    void f(float);
    vec2 &opAddAssign(const vec2 &in);
    vec2 &opSubAssign(const vec2 &in);
    vec2 &opMulAssign(float);
    vec2 &opDivAssign(float);
    bool opEquals(const vec2 &in) const;
    vec2 opAdd(const vec2 &in) const;
    vec2 opSub(const vec2 &in) const;
    vec2 opMul(float) const;
    vec2 opMul_r(float) const;
    vec2 opDiv(float) const;
};
float length(const vec2 &in);
float length_squared(const vec2 &in);
float dot(const vec2 &in, const vec2 &in);
float distance(const vec2 &in, const vec2 &in);
float distance_squared(const vec2 &in, const vec2 &in);
vec2 normalize(const vec2 &in);
vec2 reflect(const vec2 &in vec, const vec2 &in normal);
vec2 mix(vec2 a,vec2 b,float alpha);
class vec3 {
    float x;
    float y;
    float z;
    void f();
    void f(const vec3 &in);
    void f(float, float, float);
    void f(float);
    vec3 &opAddAssign(const vec3 &in);
    vec3 &opSubAssign(const vec3 &in);
    vec3 &opMulAssign(float);
    vec3 &opDivAssign(float);
    bool opEquals(const vec3 &in) const;
    vec3 opAdd(const vec3 &in) const;
    vec3 opSub(const vec3 &in) const;
    vec3 opMul(float) const;
    vec3 opMul(const vec3& in) const;
    vec3 opMul_r(float) const;
    vec3 opDiv(float) const;
    float &opIndex(int);
};
float length(const vec3 &in);
float length_squared(const vec3 &in);
float dot(const vec3 &in, const vec3 &in);
float distance(const vec3 &in, const vec3 &in);
float distance_squared(const vec3 &in, const vec3 &in);
float xz_distance(const vec3 &in, const vec3 &in);
float xz_distance_squared(const vec3 &in, const vec3 &in);
vec3 normalize(const vec3 &in);
vec3 cross(const vec3 &in, const vec3 &in);
vec3 reflect(const vec3 &in vec, const vec3 &in normal);
vec3 mix(vec3 a,vec3 b,float alpha);
class vec4 {
    float x;
    float y;
    float z;
    float a;
    void f();
    void f(const vec4 &in);
    void f(float, float, float, float);
    void f(const vec3 &in, float);
    void f(float);
vec4 mix(vec4 a,vec4 b,float alpha);
};
class ivec2 {
    int x;
    int y;
    void f();
    void f(const ivec2 &in);
    void f(int, int);
    void f(int);
    ivec2 &opAddAssign(const ivec2 &in);
    ivec2 &opSubAssign(const ivec2 &in);
    ivec2 &opMulAssign(int);
    ivec2 &opDivAssign(int);
    ivec2 opAdd(const ivec2 &in) const;
    ivec2 opSub(const ivec2 &in) const;
    ivec2 opMul(int) const;
    ivec2 opDiv(int) const;
};
class ivec3 {
    int x;
    int y;
    void f();
    void f(const ivec3 &in);
    void f(int, int, int);
    void f(int);
};
class ivec4 {
    int x;
    int y;
    void f();
    void f(const ivec4 &in);
    void f(int, int, int, int);
    void f(int);
};
class quaternion {
    float x;
    float y;
    float z;
    float w;
    void f();
    void f(const quaternion &in);
    void f(float, float, float, float);
    void f(vec4); // Axis-angle (axis.x, axis.y, axis.z, angle_radians)
    void f();
    quaternion &opAssign(const quaternion &in);
    quaternion &opAddAssign(const quaternion &in);
    bool opEquals(const quaternion &in) const;
    quaternion opAdd(const quaternion &in) const;
    quaternion opMul(const quaternion &in) const;
    vec3 opMul(const vec3 &in) const;
};
vec3 Mult(quaternion, vec3); // Applies a quaternion rotation to a vector
quaternion mix(const quaternion &in a, const quaternion &in b, float alpha);
quaternion invert(quaternion quat);
void GetRotationBetweenVectors(const vec3 &in start, const vec3 &in end, quaternion &out rotation);
class mat4 {
    void f();
    void f(const mat4 &in);
    float &opIndex(uint);
    const float &opIndex(uint) const;
    mat4 opMul(mat4) const;
    vec3 opMul(vec3) const;
    vec3 opMul(vec4) const;
    void SetTranslationPart(vec3);
    vec3 GetTranslationPart() const;
    void SetRotationPart(mat4);
    mat4 GetRotationPart() const;
    void SetRotationX(float);
    void SetRotationY(float);
    void SetRotationZ(float);
    void SetColumn(int, vec3);
    vec3 GetColumn(int);
};
mat4 transpose(mat4);
mat4 invert(mat4);
mat4 mix(const mat4 &in a, const mat4 &in b, float alpha);
class mat3 {
    void f();
    void f(const mat3 &in);
    float &opIndex(uint);
    const float &opIndex(uint) const;
    vec3 opMul(const vec3 &in) const;
};
class BoneTransform { // An efficient way to define an unscaled transformation
    quaternion rotation;
    vec3 origin;
    void f();
    void f(const mat4 &in);
    void f(const BoneTransform &in);
    bool opEquals(const BoneTransform &in) const;
    BoneTransform opMul(const BoneTransform &in) const;
    BoneTransform opMul(const BoneTransform &in) const;
    vec3 opMul(const vec3 &in) const;
    mat4 GetMat4() const;
};
BoneTransform invert(const BoneTransform &in);
BoneTransform mix(const BoneTransform &in a, const BoneTransform &in b, float alpha);
mat4 Mat4FromQuaternion(const quaternion &in);
mat3 Mat3FromQuaternion(const quaternion &in);
quaternion QuaternionFromMat4(const mat4 &in);
    string &opAssign(vec3); // These 4 functions allow us to append vec3s to strings
    string &opAddAssign(vec3);
    string opAdd(vec3) const;
    string opAdd_r(vec3) const;
float time_step; // Time in seconds between engine time steps
float the_time; // The current time in seconds since engine started (in-game time)
float ui_time; // The current time in seconds since engine started (absolute time)
void TimedSlowMotion(float target_time_scale, float how_long, float delay); // Used to trigger brief periods of slow motion
uint64 GetPerformanceCounter(); // Get high precision time info for profiling
uint64 GetPerformanceFrequency(); // Used to convert PerformanceCounter into seconds
bool GetMenuPaused(); // Is game paused by a menu
void UpdateListener(vec3 pos, vec3 vel, vec3 facing, vec3 up);
int PlaySound(string path);
int PlaySoundLoop(const string &in path, float gain);
int PlaySoundLoopAtLocation(const string &in path, vec3 pos, float gain);
void SetSoundGain(int handle, float gain);
void SetSoundPitch(int handle, float pitch);
void SetSoundPosition(int handle, vec3 pos);
void StopSound(int handle);
int PlaySound(string path, vec3 position);
int PlaySoundGroup(string path);
int PlaySoundGroup(string path, float gain);
int PlaySoundGroup(string path, vec3 position);
int PlaySoundGroup(string path, vec3 position, float gain);
int PlaySoundGroup(string path, vec3 position, int priority);
void SetAirWhoosh(float volume, float pitch);
const int _sound_priority_max;
const int _sound_priority_very_high;
const int _sound_priority_high;
const int _sound_priority_med;
const int _sound_priority_low;
bool AddMusic(const string& in);
bool RemoveMusic(const string& in);
void PlaySong(const string& in);
void SetSong(const string& in);
string GetSong();
void SetSegment(const string& in);
void QueueSegment(const string& in);
void PlaySegment(const string& in);
string GetSegment();
array<string>@ GetLayerNames();
void SetLayerGain(const string &in layer, float gain);
float GetLayerGain(const string &in layer);
void ReloadMods();
void ConnectParticles(uint32 id_a, uint32 id_b); // Used for ribbon particles, like throat-cut blood
uint32 MakeParticle(string path, vec3 pos, vec3 vel);
uint32 MakeParticle(string path, vec3 pos, vec3 vel, vec3 color);
void TintParticle(uint32 id, const vec3 &in color);
void SetSunPosition(vec3);
void SetSunColor(vec3);
void SetSunAmbient(float);
vec3 GetSunPosition();
vec3 GetSunColor();
float GetSunAmbient();
void SetFlareDiffuse(float);
void SetSkyTint(vec3);
vec3 GetSkyTint();
vec3 GetBaseSkyTint();
void SetHDRWhitePoint(float);
void SetHDRBlackPoint(float);
void SetHDRBloomMult(float);
float GetHDRWhitePoint(void);
float GetHDRBlackPoint(void);
float GetHDRBloomMult(void);
const int _delete_on_update;
const int _fade;
const int _delete_on_draw;
const int _persistent;
int DebugDrawLine(vec3 start, vec3 end, vec3 color, int lifespan);
int DebugDrawBillboard(const string &in path, vec3 center, float scale, vec4 color, int lifespan);
int DebugDrawLine(vec3 start, vec3 end, vec3 start_color, vec3 end_color, int lifespan);
int DebugDrawLine(vec3 start, vec3 end, vec4 start_color, vec4 end_color, int lifespan);
int DebugDrawRibbon(vec3 start, vec3 end, vec4 start_color, vec4 end_color, float start_width, float end_width, int lifespan);
int DebugDrawRibbon(int lifespan);
void AddDebugDrawRibbonPoint(int which, vec3 pos, vec4 color, float width);
int DebugDrawLines(const array<vec3> &vertices, vec4 color, int lifespan);
int DebugDrawText(vec3 pos, string text, float scale, bool screen_space, int lifespan);
int DebugSetPosition(int id, vec3 pos);
int DebugDrawWireSphere(vec3 pos, float radius, vec3 color, int lifespan);
int DebugDrawWireMesh(string path, mat4 transform, vec4 color, int lifespan);
int DebugDrawWireScaledSphere(vec3 pos, float radius, vec3 scale, vec3 color, int lifespan);
int DebugDrawWireScaledSphere(vec3 pos, float radius, vec3 scale, vec4 color, int lifespan);
int DebugDrawWireCylinder(vec3 pos, float radius, float height, vec3 color, int lifespan);
int DebugDrawWireBox(vec3 pos, vec3 dimensions, vec3 color, int lifespan);
int DebugDrawCircle(mat4 transform, vec4 color, int lifespan);
void DebugDrawRemove(int id);
void DebugText(string key, string display_text, float lifetime);
string FloatString(float val, int digits);
int DebugDrawPoint(vec3 pos, vec4 color, int lifespan);
void ClearTemporaryDecals(); // Like blood splats and footprints
void DisplayError(const string &in title, const string &in contents);
enum LogType {
    fatal = 32,
    error = 16,
    warning = 8,
    info = 4,
    debug = 2,
    spam = 1,
void Log( LogType level, const string &in str );
string GetBuildVersionShort( );
string GetBuildVersionFull( );
string GetBuildTimestamp( );
enum JsonValueType {
    JSONnullValue = 0,
    JSONintValue = 1,
    JSONuintValue = 2,
    JSONrealValue = 3,
    JSONstringValue = 4,
    JSONbooleanValue = 5,
    JSONarrayValue = 6,
    JSONobjectValue = 7,
class JSONValue {
    void JSONValue();
    void JSONValue( JsonValueType &in );
    void JSONValue( int &in );
    void JSONValue( uint &in);
    void JSONValue( int64 &in);
    void JSONValue( uint64 &in );
    void JSONValue( double &in );
    void JSONValue( string &in );
    void JSONValue( bool &in );
    void JSONValue( JSONValue &in );
    void JSONValue();
    JSONValue& opAssign(const JSONValue &in other);
    JSONValue& opIndex( const string &in );
    JSONValue& opIndex( const int &in );
    string asString();
    JsonValueType type();
    string typeName();
    int asInt();
    uint asUInt();
    int64 asInt64();
    uint64 asUInt64();
    float asFloat();
    double asDouble();
    bool asBool();
    bool isNull();
    bool isBool();
    bool isInt();
    bool isInt64();
    bool isUInt();
    bool isUInt64();
    bool isIntegral();
    bool isDouble();
    bool isNumeric();
    bool isString();
    bool isArray();
    bool isObject();
    bool isConvertibleTo(JsonValueType type);
    uint size();
    bool empty();
    void clear();
    void resize(uint64);
    bool isValidIndex(uint64);
    JSONValue& append(const JSONValue &in);
    bool removeMember( const string &in );
    bool removeIndex( uint  i );
    bool isMember(const string &in);
    array<string>@ getMemberNames();
class JSON {
    void JSON();
    void JSON();
    JSON& opAssign(const JSON &in other);
    bool parseString(string &in);
    bool parseFile(string &in);
    string writeString(bool=false);
    JSONValue& getRoot();
string GetConfigValueString(string index);
array<string>@ GetConfigValueOptions(string index);
float GetConfigValueFloat(string index);
void SetConfigValueFloat(string key, float value);
bool GetConfigValueBool(string index);
void SetConfigValueString(string key, string value);
void SetConfigValueBool(string key, bool value);
void SetConfigValueInt(string key, int value);
int GetConfigValueInt(string key);
int GetMonitorCount();
array<vec2>@ GetPossibleResolutions();
void ReloadStaticValues();
array<string>@ GetAvailableBindingCategories();
array<string>@ GetAvailableBindings(const string& in);
string GetBindingValue(string binding_category, string binding);
void SetBindingValue(string binding_category, string binding, string value);
void SetKeyboardBindingValue(string binding_category, string binding, uint32 scancode);
void SetMouseBindingValue(string binding_category, string binding, uint32 button);
void SetMouseBindingValue(string binding_category, string binding, string text);
void SetControllerBindingValue(string binding_category, string binding, uint32 input);
void SaveConfig();
bool ConfigHasKey(string key);
void ResetBinding(string binding_category, string binding);
string ToUpper(string &in);
uint GetLengthInBytesForNCodepoints( const string& in, uint codepoint_index );
uint GetCodepointCount( const string& in );
bool DirectoryExists(string& in);
bool FileExists(string& in);
class LevelDetails {
    void f();
    string GetName();
};
enum UserVote {
    k_VoteUnknown = 0,
    k_VoteNone = 1,
    k_VoteUp = 2,
    k_VoteDown = 3,
class Parameter {
    void f();
    void f(const Parameter &in other);
    void f();
    Parameter& opAssign(const Parameter &in other);
    Parameter opIndex( const string &in );
    Parameter opIndex( const int &in );
    string getName();
    bool isEmpty();
    bool isString();
    bool isArray();
    bool isTable();
    uint size();
    string asString();
    bool contains(const string &in value);
    bool containsName(const string &in value);
class ModID {
    void f();
    void f();
    bool Valid();
};
class MenuItem {
    void f();
    void f();
    string GetTitle();
    string GetCategory();
    string GetPath();
    string GetThumbnail();
};
class SpawnerItem {
    void SpawnerItem();
    void SpawnerItem();
    string GetTitle();
    string GetCategory();
    string GetPath();
    string GetThumbnail();
};
class ModLevel {
    void f();
    void f(const ModLevel &in other);
    void f();
    ModLevel& opAssign(const ModLevel &in other);
    string GetTitle();
    string GetID();
    string GetThumbnail();
    string GetPath();
    LevelDetails GetDetails();
    bool CompletionOptional();
    Parameter GetParameter();
};
class Campaign {
    void f();
    void f(const Campaign &in other);
    void f();
    Campaign& opAssign(const Campaign &in other);
    string GetID();
    string GetTitle();
    string GetThumbnail();
    string GetMainScript();
    string GetMenuScript();
    string GetAttribute(string &in id);
    array<ModLevel>@ GetLevels();
    ModLevel GetLevel(string &in id);
    Parameter GetParameter();
Campaign GetCampaign(string& campaign_id);
array<Campaign>@ GetCampaigns();
bool ModIsActive(ModID& id);
bool ModNeedsRestart(ModID& id);
bool ModIsValid(ModID& id);
bool ModIsCore(ModID& id);
bool ModCanActivate(ModID& id);
int ModGetSource(ModID& id);
string ModGetID(ModID& id);
string ModGetName(ModID& id);
string ModGetAuthor(ModID& id);
string ModGetVersion(ModID& id);
string ModGetTags(ModID& id);
string ModGetPath(ModID& sid);
string ModGetValidityString(ModID& sid);
string ModGetDescription(ModID& id);
string ModGetThumbnail(ModID& sid);
array<MenuItem>@ ModGetMenuItems(ModID& sid);
array<SpawnerItem>@ ModGetSpawnerItems(ModID& sid);
array<SpawnerItem>@ ModGetAllSpawnerItems(bool only_include_active = true);
array<ModLevel>@ ModGetCampaignLevels(ModID& sid);
array<ModLevel>@ ModGetSingleLevels(ModID& sid);
UserVote ModGetUserVote(ModID& sid);
void RequestModSetUserVote(ModID& id, bool voteup);
void RequestModSetFavorite(ModID& id, bool fav);
bool ModIsFavorite(ModID& id);
array<ModID>@ GetModSids();
array<ModID>@ GetActiveModSids();
bool ModActivation(ModID& sid, bool active);
void RequestWorkshopSubscribe(ModID& id);
void RequestWorkshopUnSubscribe(ModID& id);
bool IsWorkshopSubscribed(ModID& id);
bool IsWorkshopMod(ModID& id);
bool IsWorkshopAvailable();
void SaveModConfig();
void OpenModWorkshopPage(ModID& id);
void OpenModAuthorWorkshopPage(ModID& id);
void OpenWorkshop();
void DeactivateAllMods();
uint WorkshopSubscribedNotInstalledCount();
uint WorkshopDownloadingCount();
uint WorkshopDownloadPendingCount();
uint WorkshopNeedsUpdateCount();
float WorkshopTotalDownloadProgress();
void StorageSetString(string index, string value);
bool StorageHasString(string index);
string StorageGetString(string index);
void StorageSetInt32(string index, int value);
bool StorageHasInt32(string index);
int StorageGetInt32(string index);
void PrintCallstack();
class ASContext {
    void PrintGlobalVars();
};
ASContext context;
uint SOCKET_ID_INVALID;
uint CreateSocketTCP(string& host, uint16 port);
void DestroySocketTCP(uint socket);
int SocketTCPSend(uint socket, const array<uint8>& data);
bool IsValidSocketTCP(uint socket);
bool GetInputDown(int controller_id, const string &in input_label);
bool GetInputDownFiltered(int controller_id, const string &in input_label, uint filter);
bool GetInputPressed(int controller_id, const string &in input_label);
bool GetInputPressedFiltered(int controller_id, const string &in input_label, uint filter);
void ActivateKeyboardEvents();
void DeactivateKeyboardEvents();
void StartTextInput();
void StopTextInput();
float GetLookXAxis(int controller_id);
float GetLookYAxis(int controller_id);
float GetMoveXAxis(int controller_id);
float GetMoveYAxis(int controller_id);
void SetGrabMouse(bool);
bool DebugKeysEnabled();
bool EditorEnabled();
void LoadEditorLevel();
bool IsKeyDown(int key_code);
int GetCodeForKey(string key_name);
string GetStringDescriptionForBinding( const string& in, const string& in );
string GetLocaleStringForScancode(int scancode);
string GetStringForMouseButton(int button);
string GetStringForControllerInput(int input);
string GetStringForMouseString(const string& text);
enum KeyboardInputModeFlag {
    KIMF_NO = 0,
    KIMF_MENU = 1,
    KIMF_PLAYING = 2,
    KIMF_LEVEL_EDITOR_GENERAL = 4,
    KIMF_LEVEL_EDITOR_DIALOGUE_EDITOR = 8,
    KIMF_GUI_GENERAL = 16,
    KIMF_ANY = 268435455,
enum SDLNumeric {
    K_ESCAPE = 27,
    K_ENTER = 13,
    KP_ENTER = 1073741912,
    K_BACKSPACE = 8,
    K_TAB = 9,
    K_0 = 48,
    K_1 = 49,
    K_2 = 50,
    K_3 = 51,
    K_4 = 52,
    K_5 = 53,
    K_6 = 54,
    K_7 = 55,
    K_8 = 56,
    K_9 = 57,
    KP_0 = 1073741922,
    KP_1 = 1073741913,
    KP_2 = 1073741914,
    KP_3 = 1073741915,
    KP_4 = 1073741916,
    KP_5 = 1073741917,
    KP_6 = 1073741918,
    KP_7 = 1073741919,
    KP_8 = 1073741920,
    KP_9 = 1073741921,
uint GetInputMode();
class KeyboardPress {
    uint16 s_id;
    uint32 keycode;
    uint32 scancode;
    uint16 mod;
float last_keyboard_event_time;
float last_mouse_event_time;
float last_controller_event_time;
array<KeyboardPress>@ GetRawKeyboardInputs();
enum MouseButton {
    LEFT = 0,
    MIDDLE = 1,
    RIGHT = 2,
    FOURTH = 3,
    FIFTH = 4,
    SIXTH = 5,
    SEVENTH = 6,
    EIGHT = 7,
    NINTH = 8,
    TENTH = 9,
    TWELFTH = 10,
class MousePress {
    uint16 s_id;
    MouseButton button;
array<MousePress>@ GetRawMouseInputs();
enum ControllerInput {
    A = 0,
    B = 1,
    X = 2,
    Y = 3,
    D_UP = 4,
    D_RIGHT = 5,
    D_DOWN = 6,
    D_LEFT = 7,
    START = 8,
    BACK = 9,
    GUIDE = 10,
    L_STICK_PRESSED = 11,
    R_STICK_PRESSED = 12,
    LB = 13,
    RB = 14,
    L_STICK_XN = 22,
    L_STICK_XP = 23,
    L_STICK_YN = 24,
    L_STICK_YP = 25,
    R_STICK_XN = 26,
    R_STICK_XP = 27,
    R_STICK_YN = 28,
    R_STICK_YP = 29,
    L_TRIGGER = 19,
    R_TRIGGER = 20,
class ControllerPress {
    uint32 s_id;
    ControllerInput input;
    float depth;
array<ControllerPress>@ GetRawControllerInputs(int which);
bool IsControllerConnected();
class Camera {
    vec3 &GetTint();
    void SetTint(const vec3 &in);
    vec3 &GetVignetteTint();
    void SetVignetteTint(const vec3 &in);
    void FixDiscontinuity();
    vec3 GetFacing();
    vec3 GetFlatFacing();
    vec3 GetMouseRay(); // Direction that mouse cursor is pointing
    float GetXRotation();
    void SetXRotation(float);
    float GetYRotation();
    void SetYRotation(float);
    float GetZRotation();
    void SetZRotation(float);
    vec3 GetPos();
    vec3 GetUpVector();
    void SetPos(vec3);
    void SetFacing(vec3);
    void SetUp(vec3);
    void CalcFacing();
    void SetVelocity(vec3);
    void LookAt(vec3 target);
    void SetFOV(float);
    float GetFOV();
    bool GetAutoCamera();
    void SetDistance(float); // From orbit point, for chase camera
    void SetInterpSteps(int); // Number of time steps between camera updates
    int GetFlags();
    void SetFlags(int);
    void CalcUp();
    void SetDOF(float near_blur, float near_dist, float near_transition, float far_blur, float far_dist, float far_transition);
};
Camera camera;
bool GetSplitscreen();
int GetBloodLevel();
const vec3 &GetBloodTint();
enum CameraFlags {
    kEditorCamera = 1,
    kPreviewCamera = 2,
};
int GetScreenWidth();
int GetScreenHeight();
class Physics {
    vec3 gravity_vector;
};
Physics physics;
enum EngineState {
    kEngineNoState = 0,
    kEngineLevelState = 1,
    kEngineEditorLevelState = 2,
    kEngineEngineScriptableUIState = 3,
    kEngineCampaignState = 4,
enum SplitScreenMode {
    kModeNone = 0,
    kModeFull = 1,
    kModeSplit = 2,
void LoadLevel(string level_path);
void LoadLevelID(string id);
void SetCampaignID(string id);
string GetCurrLevelAbsPath();
string GetCurrLevel();
string GetCurrLevelRelPath();
string GetLevelName(const string& path);
string GetCurrLevelName();
string GetCurrLevelID();
string GetCurrCampaignID();
string GetCurrentMenuModsourceID();
string GetCurrentLevelModsourceID();
bool EditorModeActive();
void assert(bool val);
void SetSplitScreenMode(SplitScreenMode mode);
int GetNumCharacters();
int GetNumHotspots();
int GetNumItems();
void GetCharactersInSphere(vec3 position, float radius, array<int>@ id_array);
void GetCharacters(array<int>@ id_array);
void GetCharactersInHull(string model_path, mat4, array<int>@ id_array);
void GetObjectsInHull(string model_path, mat4, array<int>@ id_array);
void ResetLevel();
bool DoesItemFitInItem(int item_id, int holster_item_id);
float GetFriction(const vec3 &in position);
void CreateCustomHull(const string &in key, const array<vec3> &vertices);
class Object {
class AnimationClient {
    float GetAnimationEventTime(const string &in event);
    float GetTimeUntilEvent(const string &in event);
    void SetAnimationCallback(const string &in function);
    void AddAnimationOffset(const vec3 &in);
    void AddAnimationRotOffset(float radians);
    int AddLayer(const string &in anim_path, float transition_speed, int8 flags);
    int RemoveLayer(int id, float transition_speed);
    void SetBlendCoord(const string &in coord_label, float coord_value);
    void SetLayerOpacity(int id, float opacity);
    void SetSpeedMult(float);
    void SetAnimatedItemID(int index, int id);
    void SetLayerItemID(int layer, int index, int id);
    const string& GetCurrAnim();
    float GetNormalizedAnimTime();
    float GetAnimationSpeed();
    void RemoveAllLayers();
    void Reset();
};
class Skeleton {
    vec3 GetCenterOfMass();
    void SetBoneInflate(int bone_id, float amount);
    int GetParent(int bone_id);
    bool IKBoneExists(const string& in);
    float GetBoneMass(int bone_id);
    int IKBoneStart(const string& in IK_label);
    int IKBoneLength(const string& in IK_label);
    int NumBones();
    vec3 GetBoneLinearVelocity(int which);
    mat4 GetBoneTransform(int bone_id);
    void SetBoneTransform(int bone_id, const mat4 &in transform);
    vec3 GetPointPos(int bone_id);
    int GetBonePoint(int bone_id, int which_point);
    void AddVelocity(const vec3 &in vel);
    mat4 GetBindMatrix(int bone_id);
    bool HasPhysics(int bone_id);
    array<float> @GetConvexHullPoints(int bone_id);
    BoneTransform ApplyParentRotations(const array<BoneTransform> &in matrices, int id);
};
class RiggedObject {
    bool ik_enabled;
    int anim_update_period;
    int curr_anim_update_time;
    vec3 GetBonePosition(int bone);
    void AddWaterCube(const mat4 &in transform);
    void Ignite();
    void Extinguish();
    void SetFire(float fire);
    void SetWet(float wet);
    BoneTransform GetFrameMatrix(int which);
    void SetFrameMatrix(int which, const BoneTransform &in transform);
    float GetCharScale();
    float GetRelativeCharScale();
    void Draw();
    void CutPlane(const vec3 &in normal, const vec3 &in position, const vec3 &in direction, int type, int depth);
    void Stab(const vec3 &in position, const vec3 &in direction, int type, int depth);
    void SetRagdollStrength(float);
    void RefreshRagdoll();
    void SetRagdollDamping(float);
    void ApplyForceToRagdoll(const vec3 &in force, const vec3 &in position);
    void ApplyForceToBone(const vec3 &in force, const int &in bone);
    void ApplyForceLineToRagdoll(const vec3 &in force, const vec3 &in position, const vec3 &in line_direction);
    void MoveRagdollPart(const string &in, const vec3 &in, float);
    void FixedRagdollPart(int boneID, const vec3 &in);
    void SpikeRagdollPart(int boneID, const vec3 &start, const vec3 &end, const vec3 &pos);
    void ClearBoneConstraints();
    vec3 GetAvgPosition();
    vec3 GetAvgVelocity();
    void CleanBlood();
    void CreateBloodDrip(const string &in IK_label, int IK_link, const vec3 &in raycast_direction);
    void CreateBloodDripAtBone(int bone_id, int IK_link, const vec3 &in raycast_direction);
    vec3 GetAvgAngularVelocity();
    vec3 GetIKTargetPosition(const string &in IK_label);
    float GetIKWeight(const string &in IK_label);
    BoneTransform GetIKTransform(const string &in IK_label);
    mat4 GetUnmodifiedIKTransform(const string &in IK_label);
    mat4 GetIKTargetTransform(const string &in IK_label);
    void SetMorphTargetWeight(const string &in morph_label, float weight, float weight_weight);
    float GetStatusKeyValue(const string &in status_key_label);
    vec3 GetIKTargetAnimPosition(const string &in IK_label);
    mat4 GetAvgIKChainTransform(const string &in IK_label);
    mat4 GetIKChainTransform(const string &in IK_label, int IK_link);
    vec3 GetIKChainPos(const string &in IK_label, int IK_link);
    void DisableSleep();
    void EnableSleep();
    vec3 GetAvgIKChainPos(const string &in IK_label);
    void SetAnimUpdatePeriod(int steps); // Animation is updated every N engine time steps
    void SheatheItem(int item_id, bool on_right);
    void UnSheatheItem(int item_id, bool on_right);
    void UnStickItem(int item_id);
    void SetPrimaryWeaponID(int item_id);
    vec3 GetModelCenter();
    void RotateBoneToMatchVec(const vec3 &in a, const vec3 &in b, int bone);
    void RotateBonesToMatchVec(const vec3 &in a, const vec3 &in c, int bone, int bone2, float weight);
    void TransformAllFrameMats(const BoneTransform &in transform);
    vec3 GetFrameCenterOfMass();
    vec3 GetTransformedBonePoint(int bone, int point);
    mat4 GetDisplayBoneMatrix(int bone);
    void SetDisplayBoneMatrix(int bone, const mat4 &in transform);
    Skeleton &skeleton();
    AnimationClient &anim_client();
};
const int _awake;
const int _unconscious;
const int _dead;
class MovementObject {
    vec3 position;
    vec3 velocity;
    bool visible;
    int no_grab;
    string char_path;
    bool controlled;
    bool is_player;
    bool static_char;
    int controller_id;
    int update_script_counter;
    int update_script_period;
    bool focused_character;
    RiggedObject@ rigged_object();
    void SetScriptUpdatePeriod(int steps); // Script update() is called every X engine timesteps
    bool HasFunction(const string &in function_definition);
    int QueryIntFunction(string function);
    void Execute(string code);
    bool HasVar(string var_name);
    int GetIntVar(string var_name);
    int GetArrayIntVar(const string &in var_name, int index);
    float GetFloatVar(string var_name);
    bool GetBoolVar(string var_name);
    bool OnSameTeam(MovementObject@ other);
    void ReceiveMessage(const string &in);
    void ReceiveScriptMessage(const string &in);
    void QueueScriptMessage(const string &in);
    int GetID();
    void SetRotationFromFacing(vec3 facing);
    void FixDiscontinuity();
    string GetCurrentControlScript();
    string GetActorScript();
    string GetNPCObjectScript();
    string GetPCObjectScript();
    string GetNPCScript();
    string GetPCScript();
    void ChangeControlScript(const string &path);
};
class ScriptParams {
    const string &GetString (const string &in key);
    float GetFloat (const string &in key);
    int GetInt (const string &in key);
    float SetFloat (const string &in key, float val);
    int SetInt (const string &in key, int);
    void SetString (const string &in key, const string &in val);
    void AddInt (const string &in key, int default_val);
    void AddIntSlider (const string &in key, int default_val, const string &in bounds);
    void AddFloatSlider (const string &in key, float default_val, const string &in bounds);
    void AddIntCheckbox (const string &in key, bool default_val);
    void AddFloat (const string &in key, float default_val);
    void AddString (const string &in key, const string &in default_val);
    void ASAddJSONFromString (const string &in key, const string &in default_val);
    void AddJSON (const string &in key, JSON &in default_val);
    JSON GetJSON (const string &in key);
    void Remove (const string &in key);
    bool HasParam (const string &in key);
    bool IsParamInt(const string &in key);
    bool IsParamFloat(const string &in key);
    bool IsParamString(const string &in key);
    bool IsParamJSON(const string &in key);
};
class ItemObject {
    vec3 GetPhysicsPosition();
    vec3 GetLinearVelocity();
    vec3 GetAngularVelocity();
    void SetAngularVelocity(vec3);
    void AddBloodDecal(vec3 position, vec3 direction, float size);
    void CleanBlood();
    mat4 GetPhysicsTransform();
    mat4 GetPhysicsTransformIncludeOffset();
    void SetPhysicsTransform(const mat4 &in);
    void ActivatePhysics();
    bool IsHeld();
    int StuckInWhom();
    int HeldByWhom();
    int GetID();
    void SetLinearVelocity(vec3);
    const string& GetLabel();
    void SetThrown();
    void SetThrownStraight();
    float GetMass();
    bool HasSheatheAttachment();
    int GetNumHands();
    int GetType();
    vec3 GetPoint(string label);
    int GetNumLines();
    vec3 GetLineStart(int line_index);
    vec3 GetLineEnd(int line_index);
    string GetLineMaterial(int line_index);
    const string &GetSoundModifier();
    float GetRangeExtender();
    float GetRangeMultiplier();
    bool CheckThrownSafe();
    void SetSafe();
    ScriptParams@ GetScriptParams();
    int last_held_char_id_;
};
const int _collectable;
const int _misc;
const int _weapon;
const int _item_no_type;
class EnvObject {
    int GetID();
    void CreateLeaf(vec3 target_position, vec3 velocity, int iterations); // Spawn leaf particles from random point on object's surface; more iterations = closer to target_position
    int GetCollisionFace(int index);
    vec3 GetCollisionVertex(int index);
    int GetNumLedgeLines();
    int GetLedgeLine(int index);
};
class Hotspot {
    int GetID();
    string GetTypeString();
    bool HasVar(string& in name);
    bool GetBoolVar(string& in name);
    int GetIntVar(string& in name);
    int GetArrayIntVar(const string &in name, int index);
    float GetFloatVar(string& in name);
    array<int> @GetConnectedObjects();
    bool HasFunction(const string &in function_definition);
    int QueryIntFunction(const string &in function);
    bool QueryBoolFunction(const string &in function);
    float QueryFloatFunction(const string &in function);
    string QueryStringFunction(const string &in function);
    void SetCollisionEnabled(bool);
    bool ConnectTo(Object@);
    bool Disconnect(Object@);
void CFireRibbonUpdate(C_ACCEL @, float delta_time, float curr_game_time, vec3 &in pos);
void CFireRibbonPreDraw(C_ACCEL @, float curr_game_time);
};
enum EntityType {
    _any_type = 0,
    _no_type = 1,
    _camera_type = 2,
    _terrain_type = 11,
    _env_object = 20,
    _movement_object = 21,
    _spawn_point = 23,
    _decal_object = 24,
    _hotspot_object = 26,
    _group = 29,
    _rigged_object = 30,
    _item_object = 32,
    _path_point_object = 33,
    _ambient_sound_object = 34,
    _placeholder_object = 35,
    _light_probe_object = 36,
    _dynamic_light_object = 37,
    _navmesh_hint_object = 38,
    _navmesh_region_object = 39,
    _navmesh_connection_object = 40,
    _reflection_capture_object = 41,
    _light_volume_object = 42,
    _prefab = 43,
};
enum AttachmentType {
    _at_attachment = 2,
    _at_grip = 0,
    _at_sheathe = 1,
    _at_unspecified = 3,
};
enum ConnectionType {
    kCTNone = 0,
    kCTMovementObjects = 1,
    kCTItemObjects = 2,
    kCTEnvObjectsAndGroups = 3,
    kCTPathPoints = 4,
    kCTPlaceholderObjects = 5,
    kCTNavmeshConnections = 6,
    kCTHotspots = 7,
};
    int GetID();
    string GetName();
    void SetName(const string &in);
    bool IsSelected();
    void SetSelected(bool);
    void SetEnabled(bool);
    void SetCollisionEnabled(bool);
    bool GetEnabled();
    void SetTranslation(const vec3 &in);
    vec3 GetTranslation();
    void SetScale(const vec3 &in);
    mat4 GetTransform();
    vec3 GetScale();
    void SetRotation(const quaternion &in);
    void SetTranslationRotationFast(const vec3 &in, const quaternion &in);
    quaternion GetRotation();
    vec4 GetRotationVec4();
    EntityType GetType();
    void SetPlayer(bool);
    bool GetPlayer();
    int GetNumPaletteColors();
    vec3 GetPaletteColor(int which);
    void SetPaletteColor(int which, const vec3 &in color);
    vec3 GetTint();
    void SetTint(const vec3 &in);
    bool ConnectTo(Object@);
    bool Disconnect(Object@);
    void AttachItem(Object@, AttachmentType, bool mirrored);
    void ReceiveScriptMessage(const string &in);
    void QueueScriptMessage(const string &in);
    void UpdateScriptParams();
    void SetCopyable(bool);
    void SetSelectable(bool);
    void SetDeletable(bool);
    void SetScalable(bool);
    void SetTranslatable(bool);
    void SetRotatable(bool);
    void SetEditorLabel(string);
    string GetEditorLabel();
    void SetEditorLabelOffset(vec3);
    vec3 GetEditorLabelOffset();
    void SetEditorLabelScale(float);
    float GetEditorLabelScale();
    ScriptParams@ GetScriptParams();
    string GetLabel();
    vec3 GetBoundingBox();
    bool IsExcludedFromSave();
    bool IsExcludedFromUndo();
    int GetParent();
    array<int>@ GetChildren();
};
Object@ ReadObjectFromID(int);
bool ObjectExists();
array<int> @GetObjectIDs();
array<int> @GetObjectIDsType(int type);
void DeleteObjectID(int);
void QueueDeleteObjectID(int);
int CreateObject(const string &in path, bool exclude_from_save);
int CreateObject(const string &in path);
int DuplicateObject(Object@ obj);
void DeselectAll();
array<int> @GetSelected();
class PathPointObject {
    int NumConnectionIDs();
    int GetConnectionID(int which);
};
    PathPointObject@ opCast();
    Hotspot@ opCast();
MovementObject@ ReadCharacter(int index); // e.g. first character in scene
MovementObject@ ReadCharacterID(int id); // e.g. character with object ID 39
Hotspot@ ReadHotspot(int index);
ItemObject@ ReadItem(int index);
ItemObject@ ReadItemID(int id);
EnvObject@ ReadEnvObjectID(int id);
bool ObjectExists(int id);
bool MovementObjectExists(int id);
bool IsGroupDerived(int id);
void SetPaused(bool paused);
int FindFirstCharacterInGroup(int id);
void SendMessage(int target, int type, vec3 vec_a, vec3 vec_b);
void SendMessage(int type, string msg);
void SendGlobalMessage(string msg);
int _plant_movement_msg;
int _editor_msg;
float atof(const string &in str);
int atoi(const string &in str);
class TextStyle {
    int font_face_id;
    void f();
    void f();
    void SetAlignment(int i);
};
class TextMetrics {
    int advance_x;
    int advance_y;
    int bounds_x;
    int bounds_y;
    float ascenderRatio;
};
class TextCanvasTexture {
    void Create(int width, int height);
    void ClearTextCanvas();
    void UploadTextCanvasToTexture();
    void DebugDrawBillboard(const vec3 &in pos, float scale, int lifespan);
    void AddText(const string &in, const TextStyle &in, uint char_limit);
    void AddTextMultiline(const string &in, const TextStyle &in, uint char_limit);
    void GetTextMetrics(const string &in, const TextStyle &in, TextMetrics &out, uint char_limit);
    void SetPenPosition(const vec2 &in);
    void SetPenColor(int r, int g, int b, int a);
    void SetPenRotation(float rotation);
};
enum TextAtlasFlags {
    kSmallLowercase = 1,
};
int GetFontFaceID(const string &in path, int pixel_height);
void DisposeTextAtlases();
void DrawTextAtlas(const string &in path, int pixel_height, int flags, const string &in txt, int x, int y, vec4 color);
void DrawTextAtlas2(const string &in path, int pixel_height, int flags, const string &in txt, int x, int y, vec4 color, uint char_limit);
TextMetrics GetTextAtlasMetrics(const string &in path, int pixel_height, int flags, const string &in txt );
TextMetrics GetTextAtlasMetrics2(const string &in path, int pixel_height, int flags, const string &in txt, uint char_limit );
class Level {
    bool HasFunction(const string &in function_definition);
    int QueryIntFunction(const string &in function);
    int GetNumObjectives();
    int GetNumAchievements();
    string GetObjective(int which);
    string GetAchievement(int which);
    void SendMessage(const string& in message);
    void Execute(string code);
    const string& GetPath(const string& in key); // Get path from paths xml file
    bool HasFocus();
    bool DialogueCameraControl();
    bool LevelBoundaries();
    int CreateTextElement();
    void DeleteTextElement(int which);
    TextCanvasTexture@ GetTextElement(int which);
    void GetCollidingObjects(int id, array<int> @array);
    void ReceiveLevelEvents(int id);
    void StopReceivingLevelEvents(int id);
    bool HasVar(const string &in name);
    int GetIntVar(const string &in name);
    int GetArrayIntVar(const string &in name, int index);
    float GetFloatVar(const string &in name);
    bool GetBoolVar(const string &in name);
    bool WaitingForInput();
    ScriptParams@ GetScriptParams();
};
Level level;
bool CheckSaveLevelChanges();
void ClearUndoHistory();
void RibbonItemSetEnabled(const string &in, bool);
void RibbonItemSetToggled(const string &in, bool);
void RibbonItemFlash(const string &in);
bool MediaMode();
void SetMediaMode(bool);
void SetInterlevelData(const string &in, const string &in);
string GetInterlevelData(const string &in);
enum UIState {
    kNothing = 0,
    kHot = 1,
    kActive = 2,
enum UIMouseState {
    kMouseUp = 0,
    kMouseDown = 1,
    kMouseStillUp = 2,
    kMouseStillDown = 3,
enum TextFlags {
    kTextShadow = 1,
class IMUIImage {
    void setPosition( vec3 newPos );
    void setColor( vec4 newColor );
    void setRotation( float newRotation );
    void setClipping( vec2 offset, vec2 size );
    void disableClipping();
    void f();
    void f( string filename );
    void f( const IMUIImage &in other );
    IMUIImage& opAssign(const IMUIImage &in other);
    void f();
    bool loadImage( string filename );
    bool isValid() const;
    float getTextureWidth() const;
    float getTextureHeight() const;
    void setRenderOffset( vec2 offset, vec2 size );
    void setRenderSize( vec2 size );
class IMUIText {
    void setPosition( vec3 newPos );
    void setColor( vec4 newColor );
    void setRotation( float newRotation );
    void setClipping( vec2 offset, vec2 size );
    void disableClipping();
    void f();
    void f( const IMUIText &in other );
    IMUIText& opAssign(const IMUIText &in other);
    void f();
    vec2 getDimensions() const;
    vec2 getBoundingBoxDimensions() const;
    void setText( const string &in _text );
    void setRenderFlags( int newFlags );
class IMUIContext {
int CreateIMUIContext();
IMUIContext@ GetIMUIContext(int id);
void DisposeIMUIContext(int id);
    void UpdateControls();
    bool DoButton(int, vec2, vec2, UIState &out);
    void Init();
    vec2 getMousePosition();
    UIMouseState getLeftMouseState();
    void queueImage( IMUIImage &in newImage  );
    void queueText( IMUIText &in newText );
    IMUIText makeText( string &in fontName, int size, int fontFlags, int renderFlags = 0 );
    void render();
    void clearTextAtlases();
const float UNDEFINEDSIZE;
const int UNDEFINEDSIZEI;
enum DividerOrientation {
    DOVertical = 0,
    DOHorizontal = 1,
enum ContainerAlignment {
    CATop = 0,
    CALeft = 0,
    CACenter = 1,
    CARight = 2,
    CABottom = 2,
enum ExpansionPolicy {
    ContainerExpansionStatic = 0,
    ContainerExpansionExpand = 1,
    ContainerExpansionInheritMax = 2,
class IMMessage {
    void f();
    void f();
    string name;
    IMMessage@ f( const string &in name);
    IMMessage@ f( const string &in name, int param );
    IMMessage@ f( const string &in name, float param );
    IMMessage@ f( const string &in name, const string &in param );
    int numInts();
    int numFloats();
    int numStrings();
    void addInt( int param );
    void addFloat( float param );
    void addString( const string &in param );
    int getInt( int index ) ;
    float getFloat( int index ) ;
    string getString( int index ) ;
class CItem {
    CItem@ f();
    void f();
    void f();
    bool execute_on_select;
    bool skip_show_border;
    void setMessage(IMMessage@ message);
    void setMessageOnSelect(IMMessage@ message);
    void setMessages(IMMessage@ message, IMMessage@ message_on_select, IMMessage@ message_left, IMMessage@ message_right, IMMessage@ message_up, IMMessage@ message_down);
    IMMessage@ getMessage();
    IMMessage@ getMessageOnSelect();
    IMMessage@ getMessageLeft();
    IMMessage@ getMessageRight();
    IMMessage@ getMessageUp();
    IMMessage@ getMessageDown();
    bool isActive();
class GUIState {
    vec2 mousePosition;
    UIMouseState leftMouseState;
vec4 HexColor(const string &in hex);
class FontSetup {
    void f();
    void f( const string &in _name, int32 _size, vec4 _color, bool _shadowed = false );
    void f( const FontSetup &in other );
    FontSetup& opAssign(const FontSetup &in other);
    void f();
    string fontName;
    int size;
    vec4 color;
    float rotation;
    bool shadowed;
class SizePolicy {
    void f();
    void f( float _defaultSize );
    void f();
    void f( const SizePolicy &in other );
    IMUIText& opAssign(const SizePolicy &in other);
    SizePolicy expand( float _maxSize = UNDEFINEDSIZE );
    SizePolicy inheritMax();
    SizePolicy staticMax();
    SizePolicy overflowClip( bool shouldClip );
enum IMTweenType {
    linearTween = 0,
    inQuadTween = 1,
    outQuadTween = 2,
    inOutQuadTween = 3,
    outInQuadTween = 4,
    inCubicTween = 5,
    outCubicTween = 6,
    inOutCubicTween = 7,
    outInCubicTween = 8,
    inQuartTween = 9,
    outQuartTween = 10,
    inOutQuartTween = 11,
    outInQuartTween = 12,
    inQuintTween = 13,
    outQuintTween = 14,
    inOutQuintTween = 15,
    outInQuintTween = 16,
    inSineTween = 17,
    outSineTween = 18,
    inOutSineTween = 19,
    outInSineTween = 20,
    inExpoTween = 21,
    outExpoTween = 22,
    inOutExpoTween = 23,
    outInExpoTween = 24,
    inCircTween = 25,
    outCircTween = 26,
    inOutCircTween = 27,
    outInCircTween = 28,
    outBounceTween = 29,
    inBounceTween = 30,
    inOutBounceTween = 31,
    outInBounceTween = 32,
class IMUpdateBehavior {
    IMUpdateBehavior@ f();
    void f();
    void f();
class IMMouseOverBehavior {
    IMMouseOverBehavior@ f();
    void f();
    void f();
class IMMouseClickBehavior {
    IMMouseClickBehavior@ f();
    void f();
    void f();
class IMFadeIn {
    IMFadeIn@ f(uint64 time, IMTweenType _tweener);
    IMFadeIn@ opCast();
    IMUpdateBehavior@ opImplCast();
    void f();
    void f();
class IMMoveIn {
    IMMoveIn@ f(uint64 time, vec2 offset, IMTweenType _tweener);
    IMMoveIn@ opCast();
    IMUpdateBehavior@ opImplCast();
    void f();
    void f();
class IMChangeTextFadeOutIn {
    IMChangeTextFadeOutIn@ f(uint64 time, const string &in _targetText, IMTweenType _tweenerOut, IMTweenType _tweenerIn);
    IMChangeTextFadeOutIn@ opCast();
    IMUpdateBehavior@ opImplCast();
    void f();
    void f();
class IMChangeImageFadeOutIn {
    IMChangeImageFadeOutIn@ f(uint64 time, const string &in _targetImage, IMTweenType _tweenerOut, IMTweenType _tweenerIn);
    IMChangeImageFadeOutIn@ opCast();
    IMUpdateBehavior@ opImplCast();
    void f();
    void f();
class IMPulseAlpha {
    IMPulseAlpha@ f(float lower, float upper, float _speed);
    IMPulseAlpha@ opCast();
    IMUpdateBehavior@ opImplCast();
    void f();
    void f();
class IMPulseBorderAlpha {
    IMPulseBorderAlpha@ f(float lower, float upper, float _speed);
    IMPulseBorderAlpha@ opCast();
    IMUpdateBehavior@ opImplCast();
    void f();
    void f();
class IMMouseOverScale {
    IMMouseOverScale@ f(uint64 time, float offset, IMTweenType _tweener);
    IMMouseOverScale@ opCast();
    IMMouseOverBehavior@ opImplCast();
    void f();
    void f();
class IMMouseOverMove {
    IMMouseOverMove@ f(uint64 time, vec2 offset, IMTweenType _tweener);
    IMMouseOverMove@ opCast();
    IMMouseOverBehavior@ opImplCast();
    void f();
    void f();
class IMMouseOverShowBorder {
    IMMouseOverShowBorder@ f();
    IMMouseOverShowBorder@ opCast();
    IMMouseOverBehavior@ opImplCast();
    void f();
    void f();
class IMMouseOverPulseColor {
    IMMouseOverPulseColor@ f(vec4 first, vec4 second, float _speed);
    IMMouseOverPulseColor@ opCast();
    IMMouseOverBehavior@ opImplCast();
    void f();
    void f();
class IMMouseOverPulseBorder {
    IMMouseOverPulseBorder@ f(vec4 first, vec4 second, float _speed);
    IMMouseOverPulseBorder@ opCast();
    IMMouseOverBehavior@ opImplCast();
    void f();
    void f();
class IMMouseOverPulseBorderAlpha {
    IMMouseOverPulseBorderAlpha@ f(vec4 first, vec4 second, float _speed);
    IMMouseOverPulseBorderAlpha@ opCast();
    IMMouseOverBehavior@ opImplCast();
    void f();
    void f();
class IMFixedMessageOnMouseOver {
    IMFixedMessageOnMouseOver@ f(IMMessage@ _enterMessage, IMMessage@ _overMessage, IMMessage@ _leaveMessage);
    IMFixedMessageOnMouseOver@ opCast();
    IMMouseOverBehavior@ opImplCast();
    void f();
    void f();
class IMMouseOverFadeIn {
    IMMouseOverFadeIn@ f(uint64 time, IMTweenType _tweener, float targetAlpha = 1.0f);
    IMMouseOverFadeIn@ opCast();
    IMMouseOverBehavior@ opImplCast();
    void f();
    void f();
class IMFixedMessageOnClick {
    IMFixedMessageOnClick@ f(IMMessage@ _enterMessage, IMMessage@ _overMessage, IMMessage@ _leaveMessage);
    IMFixedMessageOnClick@ f(const string &in messageName);
    IMFixedMessageOnClick@ f(const string &in messageName, int param);
    IMFixedMessageOnClick@ f(const string &in messageName, const string &in param);
    IMFixedMessageOnClick@ f(const string &in messageName, float param);
    IMFixedMessageOnClick@ f(IMMessage@ message);
    IMFixedMessageOnClick@ opCast();
    IMMouseClickBehavior@ opImplCast();
    void f();
    void f();
class IMElement {
    CItem controllerItem;
    void f();
    void f();
    string getElementTypeName();
    void setColor( vec4 _color );
    vec4 getColor();
    vec4 getBaseColor();
    void setEffectColor( vec4 _color );
    vec4 getEffectColor();
    void clearColorEffect();
    void setR( float value );
    float getR();
    void setG( float value );
    float getG();
    void setB( float value );
    float getB();
    void setAlpha( float value );
    float getAlpha();
    void setEffectR( float value );
    float getEffectR();
    void clearEffectR();
    void setEffectG( float value );
    float getEffectG();
    void clearEffectG();
    void setEffectB( float value );
    float getEffectB();
    void clearEffectB();
    void setEffectAlpha( float value );
    float getEffectAlpha();
    void clearEffectAlpha();
    void showBorder( bool _border = true );
    void setBorderSize( float _borderSize );
    void setBorderColor( vec4 _color );
    vec4 getBorderColor();
    void setBorderR( float value );
    float getBorderR();
    void setBorderG( float value );
    float getBorderG();
    void setBorderB( float value );
    float getBorderB();
    void setBorderAlpha( float value );
    float getBorderAlpha();
    void setZOrdering( int z );
    int getZOrdering();
    void renderAbove( IMElement@ element );
    void renderBelow( IMElement@ element );
    void setVisible( bool _show );
    void setClip( bool _clip );
    vec2 getScreenPosition();
    void addUpdateBehavior( IMUpdateBehavior@ behavior, const string &in behaviorName );
    bool removeUpdateBehavior( const string &in behaviorName );
    bool hasUpdateBehavior(const string &in behaviorName);
    void clearUpdateBehaviors();
    void addMouseOverBehavior( IMMouseOverBehavior@ behavior, const string &in behaviorName );
    bool removeMouseOverBehavior( const string &in behaviorName );
    void clearMouseOverBehaviors();
    void addLeftMouseClickBehavior( IMMouseClickBehavior@ behavior, const string &in behaviorName );
    bool removeLeftMouseClickBehavior( const string &in behaviorName );
    void clearLeftMouseClickBehaviors();
    void sendMouseDownToChildren( bool send = true );
    void sendMouseOverToChildren( bool send = true );
    void setPauseBehaviors( bool pause );
    bool isMouseOver();
    void setName( const string &in _name );
    string getName();
    void setPadding( float U, float D, float L, float R);
    void setPaddingU( float paddingSize );
    void setPaddingD( float paddingSize );
    void setPaddingL( float paddingSize );
    void setPaddingR( float paddingSize );
    void setDisplacement( vec2 newDisplacement = vec2(0,0) );
    void setDisplacementX( float newDisplacement = 0 );
    void setDisplacementY( float newDisplacement = 0 );
    vec2 getDisplacement( vec2 newDisplacement = vec2(0,0) );
    float getDisplacementX();
    float getDisplacementY();
    void setDefaultSize( vec2 newDefault );
    vec2 getDefaultSize();
    void setSize( const vec2 _size );
    void setSizeX( const float x );
    void setSizeY( const float y );
    vec2 getSize();
    float getSizeX();
    float getSizeY();
    void sendMessage( IMMessage@ theMessage );
    IMElement@ findElement( const string &in elementName );
    IMElement@ getParent();
    void setMouseOver(bool hovered);
    IMElement@ opCast();
    IMElement@ opImplCast();
class IMSpacer {
    CItem controllerItem;
    void f();
    void f();
    string getElementTypeName();
    void setColor( vec4 _color );
    vec4 getColor();
    vec4 getBaseColor();
    void setEffectColor( vec4 _color );
    vec4 getEffectColor();
    void clearColorEffect();
    void setR( float value );
    float getR();
    void setG( float value );
    float getG();
    void setB( float value );
    float getB();
    void setAlpha( float value );
    float getAlpha();
    void setEffectR( float value );
    float getEffectR();
    void clearEffectR();
    void setEffectG( float value );
    float getEffectG();
    void clearEffectG();
    void setEffectB( float value );
    float getEffectB();
    void clearEffectB();
    void setEffectAlpha( float value );
    float getEffectAlpha();
    void clearEffectAlpha();
    void showBorder( bool _border = true );
    void setBorderSize( float _borderSize );
    void setBorderColor( vec4 _color );
    vec4 getBorderColor();
    void setBorderR( float value );
    float getBorderR();
    void setBorderG( float value );
    float getBorderG();
    void setBorderB( float value );
    float getBorderB();
    void setBorderAlpha( float value );
    float getBorderAlpha();
    void setZOrdering( int z );
    int getZOrdering();
    void renderAbove( IMElement@ element );
    void renderBelow( IMElement@ element );
    void setVisible( bool _show );
    void setClip( bool _clip );
    vec2 getScreenPosition();
    void addUpdateBehavior( IMUpdateBehavior@ behavior, const string &in behaviorName );
    bool removeUpdateBehavior( const string &in behaviorName );
    bool hasUpdateBehavior(const string &in behaviorName);
    void clearUpdateBehaviors();
    void addMouseOverBehavior( IMMouseOverBehavior@ behavior, const string &in behaviorName );
    bool removeMouseOverBehavior( const string &in behaviorName );
    void clearMouseOverBehaviors();
    void addLeftMouseClickBehavior( IMMouseClickBehavior@ behavior, const string &in behaviorName );
    bool removeLeftMouseClickBehavior( const string &in behaviorName );
    void clearLeftMouseClickBehaviors();
    void sendMouseDownToChildren( bool send = true );
    void sendMouseOverToChildren( bool send = true );
    void setPauseBehaviors( bool pause );
    bool isMouseOver();
    void setName( const string &in _name );
    string getName();
    void setPadding( float U, float D, float L, float R);
    void setPaddingU( float paddingSize );
    void setPaddingD( float paddingSize );
    void setPaddingL( float paddingSize );
    void setPaddingR( float paddingSize );
    void setDisplacement( vec2 newDisplacement = vec2(0,0) );
    void setDisplacementX( float newDisplacement = 0 );
    void setDisplacementY( float newDisplacement = 0 );
    vec2 getDisplacement( vec2 newDisplacement = vec2(0,0) );
    float getDisplacementX();
    float getDisplacementY();
    void setDefaultSize( vec2 newDefault );
    vec2 getDefaultSize();
    void setSize( const vec2 _size );
    void setSizeX( const float x );
    void setSizeY( const float y );
    vec2 getSize();
    float getSizeX();
    float getSizeY();
    void sendMessage( IMMessage@ theMessage );
    IMElement@ findElement( const string &in elementName );
    IMElement@ getParent();
    void setMouseOver(bool hovered);
    IMSpacer@ opCast();
    IMElement@ opImplCast();
    IMSpacer@ f( DividerOrientation _orientation, float size);
    IMSpacer@ f(DividerOrientation _orientation );
class IMContainer {
    CItem controllerItem;
    void f();
    void f();
    string getElementTypeName();
    void setColor( vec4 _color );
    vec4 getColor();
    vec4 getBaseColor();
    void setEffectColor( vec4 _color );
    vec4 getEffectColor();
    void clearColorEffect();
    void setR( float value );
    float getR();
    void setG( float value );
    float getG();
    void setB( float value );
    float getB();
    void setAlpha( float value );
    float getAlpha();
    void setEffectR( float value );
    float getEffectR();
    void clearEffectR();
    void setEffectG( float value );
    float getEffectG();
    void clearEffectG();
    void setEffectB( float value );
    float getEffectB();
    void clearEffectB();
    void setEffectAlpha( float value );
    float getEffectAlpha();
    void clearEffectAlpha();
    void showBorder( bool _border = true );
    void setBorderSize( float _borderSize );
    void setBorderColor( vec4 _color );
    vec4 getBorderColor();
    void setBorderR( float value );
    float getBorderR();
    void setBorderG( float value );
    float getBorderG();
    void setBorderB( float value );
    float getBorderB();
    void setBorderAlpha( float value );
    float getBorderAlpha();
    void setZOrdering( int z );
    int getZOrdering();
    void renderAbove( IMElement@ element );
    void renderBelow( IMElement@ element );
    void setVisible( bool _show );
    void setClip( bool _clip );
    vec2 getScreenPosition();
    void addUpdateBehavior( IMUpdateBehavior@ behavior, const string &in behaviorName );
    bool removeUpdateBehavior( const string &in behaviorName );
    bool hasUpdateBehavior(const string &in behaviorName);
    void clearUpdateBehaviors();
    void addMouseOverBehavior( IMMouseOverBehavior@ behavior, const string &in behaviorName );
    bool removeMouseOverBehavior( const string &in behaviorName );
    void clearMouseOverBehaviors();
    void addLeftMouseClickBehavior( IMMouseClickBehavior@ behavior, const string &in behaviorName );
    bool removeLeftMouseClickBehavior( const string &in behaviorName );
    void clearLeftMouseClickBehaviors();
    void sendMouseDownToChildren( bool send = true );
    void sendMouseOverToChildren( bool send = true );
    void setPauseBehaviors( bool pause );
    bool isMouseOver();
    void setName( const string &in _name );
    string getName();
    void setPadding( float U, float D, float L, float R);
    void setPaddingU( float paddingSize );
    void setPaddingD( float paddingSize );
    void setPaddingL( float paddingSize );
    void setPaddingR( float paddingSize );
    void setDisplacement( vec2 newDisplacement = vec2(0,0) );
    void setDisplacementX( float newDisplacement = 0 );
    void setDisplacementY( float newDisplacement = 0 );
    vec2 getDisplacement( vec2 newDisplacement = vec2(0,0) );
    float getDisplacementX();
    float getDisplacementY();
    void setDefaultSize( vec2 newDefault );
    vec2 getDefaultSize();
    void setSize( const vec2 _size );
    void setSizeX( const float x );
    void setSizeY( const float y );
    vec2 getSize();
    float getSizeX();
    float getSizeY();
    void sendMessage( IMMessage@ theMessage );
    IMElement@ findElement( const string &in elementName );
    IMElement@ getParent();
    void setMouseOver(bool hovered);
    IMContainer@ opCast();
    IMElement@ opImplCast();
    IMContainer@ f(const string &in name, SizePolicy sizeX = SizePolicy(), SizePolicy sizeY  = SizePolicy());
    IMContainer@ f( SizePolicy sizeX = SizePolicy(), SizePolicy sizeY  = SizePolicy());
    void setSizePolicy( SizePolicy sizeX, SizePolicy sizeY );
    void clear();
    void addFloatingElement( IMElement@ element, const string &in name, vec2 position, int z = -1 );
    void setElement( IMElement@ element );
    void setAlignment( ContainerAlignment xAlignment, ContainerAlignment yAlignment );
    IMElement@ removeElement( const string &in name );
    void moveElement( const string &in name, vec2 newPos );
    void moveElementRelative( const string &in name, vec2 posChange );
    vec2 getElementPosition( const string &in name );
    void setBackgroundImage( const string &in fileName, vec4 color );
    IMElement@ getContents( );
    array<IMElement@>@ getFloatingContents( );
class IMDivider {
    CItem controllerItem;
    void f();
    void f();
    string getElementTypeName();
    void setColor( vec4 _color );
    vec4 getColor();
    vec4 getBaseColor();
    void setEffectColor( vec4 _color );
    vec4 getEffectColor();
    void clearColorEffect();
    void setR( float value );
    float getR();
    void setG( float value );
    float getG();
    void setB( float value );
    float getB();
    void setAlpha( float value );
    float getAlpha();
    void setEffectR( float value );
    float getEffectR();
    void clearEffectR();
    void setEffectG( float value );
    float getEffectG();
    void clearEffectG();
    void setEffectB( float value );
    float getEffectB();
    void clearEffectB();
    void setEffectAlpha( float value );
    float getEffectAlpha();
    void clearEffectAlpha();
    void showBorder( bool _border = true );
    void setBorderSize( float _borderSize );
    void setBorderColor( vec4 _color );
    vec4 getBorderColor();
    void setBorderR( float value );
    float getBorderR();
    void setBorderG( float value );
    float getBorderG();
    void setBorderB( float value );
    float getBorderB();
    void setBorderAlpha( float value );
    float getBorderAlpha();
    void setZOrdering( int z );
    int getZOrdering();
    void renderAbove( IMElement@ element );
    void renderBelow( IMElement@ element );
    void setVisible( bool _show );
    void setClip( bool _clip );
    vec2 getScreenPosition();
    void addUpdateBehavior( IMUpdateBehavior@ behavior, const string &in behaviorName );
    bool removeUpdateBehavior( const string &in behaviorName );
    bool hasUpdateBehavior(const string &in behaviorName);
    void clearUpdateBehaviors();
    void addMouseOverBehavior( IMMouseOverBehavior@ behavior, const string &in behaviorName );
    bool removeMouseOverBehavior( const string &in behaviorName );
    void clearMouseOverBehaviors();
    void addLeftMouseClickBehavior( IMMouseClickBehavior@ behavior, const string &in behaviorName );
    bool removeLeftMouseClickBehavior( const string &in behaviorName );
    void clearLeftMouseClickBehaviors();
    void sendMouseDownToChildren( bool send = true );
    void sendMouseOverToChildren( bool send = true );
    void setPauseBehaviors( bool pause );
    bool isMouseOver();
    void setName( const string &in _name );
    string getName();
    void setPadding( float U, float D, float L, float R);
    void setPaddingU( float paddingSize );
    void setPaddingD( float paddingSize );
    void setPaddingL( float paddingSize );
    void setPaddingR( float paddingSize );
    void setDisplacement( vec2 newDisplacement = vec2(0,0) );
    void setDisplacementX( float newDisplacement = 0 );
    void setDisplacementY( float newDisplacement = 0 );
    vec2 getDisplacement( vec2 newDisplacement = vec2(0,0) );
    float getDisplacementX();
    float getDisplacementY();
    void setDefaultSize( vec2 newDefault );
    vec2 getDefaultSize();
    void setSize( const vec2 _size );
    void setSizeX( const float x );
    void setSizeY( const float y );
    vec2 getSize();
    float getSizeX();
    float getSizeY();
    void sendMessage( IMMessage@ theMessage );
    IMElement@ findElement( const string &in elementName );
    IMElement@ getParent();
    void setMouseOver(bool hovered);
    IMDivider@ opCast();
    IMElement@ opImplCast();
    IMDivider@ f(const string &in name, DividerOrientation _orientation = DOVertical);
    IMDivider@ f( DividerOrientation _orientation = DOVertical);
    void setAlignment( ContainerAlignment xAlignment, ContainerAlignment yAlignment, bool reposition = true );
    void clear();
    IMSpacer@ appendSpacer( float _size );
    IMSpacer@ appendDynamicSpacer();
    uint getContainerCount();
    IMContainer@ getContainerAt( uint i );
    IMContainer@ getContainerOf( const string &in _name );
    array<IMContainer@>@ getContainers();
    IMContainer@ append( IMElement@ newElement, float containerSize = UNDEFINEDSIZE );
    DividerOrientation getOrientation();
class IMTextSelectionList {
    CItem controllerItem;
    void f();
    void f();
    string getElementTypeName();
    void setColor( vec4 _color );
    vec4 getColor();
    vec4 getBaseColor();
    void setEffectColor( vec4 _color );
    vec4 getEffectColor();
    void clearColorEffect();
    void setR( float value );
    float getR();
    void setG( float value );
    float getG();
    void setB( float value );
    float getB();
    void setAlpha( float value );
    float getAlpha();
    void setEffectR( float value );
    float getEffectR();
    void clearEffectR();
    void setEffectG( float value );
    float getEffectG();
    void clearEffectG();
    void setEffectB( float value );
    float getEffectB();
    void clearEffectB();
    void setEffectAlpha( float value );
    float getEffectAlpha();
    void clearEffectAlpha();
    void showBorder( bool _border = true );
    void setBorderSize( float _borderSize );
    void setBorderColor( vec4 _color );
    vec4 getBorderColor();
    void setBorderR( float value );
    float getBorderR();
    void setBorderG( float value );
    float getBorderG();
    void setBorderB( float value );
    float getBorderB();
    void setBorderAlpha( float value );
    float getBorderAlpha();
    void setZOrdering( int z );
    int getZOrdering();
    void renderAbove( IMElement@ element );
    void renderBelow( IMElement@ element );
    void setVisible( bool _show );
    void setClip( bool _clip );
    vec2 getScreenPosition();
    void addUpdateBehavior( IMUpdateBehavior@ behavior, const string &in behaviorName );
    bool removeUpdateBehavior( const string &in behaviorName );
    bool hasUpdateBehavior(const string &in behaviorName);
    void clearUpdateBehaviors();
    void addMouseOverBehavior( IMMouseOverBehavior@ behavior, const string &in behaviorName );
    bool removeMouseOverBehavior( const string &in behaviorName );
    void clearMouseOverBehaviors();
    void addLeftMouseClickBehavior( IMMouseClickBehavior@ behavior, const string &in behaviorName );
    bool removeLeftMouseClickBehavior( const string &in behaviorName );
    void clearLeftMouseClickBehaviors();
    void sendMouseDownToChildren( bool send = true );
    void sendMouseOverToChildren( bool send = true );
    void setPauseBehaviors( bool pause );
    bool isMouseOver();
    void setName( const string &in _name );
    string getName();
    void setPadding( float U, float D, float L, float R);
    void setPaddingU( float paddingSize );
    void setPaddingD( float paddingSize );
    void setPaddingL( float paddingSize );
    void setPaddingR( float paddingSize );
    void setDisplacement( vec2 newDisplacement = vec2(0,0) );
    void setDisplacementX( float newDisplacement = 0 );
    void setDisplacementY( float newDisplacement = 0 );
    vec2 getDisplacement( vec2 newDisplacement = vec2(0,0) );
    float getDisplacementX();
    float getDisplacementY();
    void setDefaultSize( vec2 newDefault );
    vec2 getDefaultSize();
    void setSize( const vec2 _size );
    void setSizeX( const float x );
    void setSizeY( const float y );
    vec2 getSize();
    float getSizeX();
    float getSizeY();
    void sendMessage( IMMessage@ theMessage );
    IMElement@ findElement( const string &in elementName );
    IMElement@ getParent();
    void setMouseOver(bool hovered);
    IMTextSelectionList@ opCast();
    IMElement@ opImplCast();
    IMTextSelectionList@ f(const string &in _name, FontSetup _fontSetup, float _betweenSpace, IMMouseOverBehavior@ _mouseOver = null );
    void setAlignment( ContainerAlignment xAlignment, ContainerAlignment yAlignment );
    void setItemUpdateBehaviour( IMUpdateBehavior@ behavior );
    void addEntry( const string &in name, const string &in text, const string &in message );
    void addEntry( const string &in name, const string &in text, const string &in message, const string &in param );
class IMImage {
    CItem controllerItem;
    void f();
    void f();
    string getElementTypeName();
    void setColor( vec4 _color );
    vec4 getColor();
    vec4 getBaseColor();
    void setEffectColor( vec4 _color );
    vec4 getEffectColor();
    void clearColorEffect();
    void setR( float value );
    float getR();
    void setG( float value );
    float getG();
    void setB( float value );
    float getB();
    void setAlpha( float value );
    float getAlpha();
    void setEffectR( float value );
    float getEffectR();
    void clearEffectR();
    void setEffectG( float value );
    float getEffectG();
    void clearEffectG();
    void setEffectB( float value );
    float getEffectB();
    void clearEffectB();
    void setEffectAlpha( float value );
    float getEffectAlpha();
    void clearEffectAlpha();
    void showBorder( bool _border = true );
    void setBorderSize( float _borderSize );
    void setBorderColor( vec4 _color );
    vec4 getBorderColor();
    void setBorderR( float value );
    float getBorderR();
    void setBorderG( float value );
    float getBorderG();
    void setBorderB( float value );
    float getBorderB();
    void setBorderAlpha( float value );
    float getBorderAlpha();
    void setZOrdering( int z );
    int getZOrdering();
    void renderAbove( IMElement@ element );
    void renderBelow( IMElement@ element );
    void setVisible( bool _show );
    void setClip( bool _clip );
    vec2 getScreenPosition();
    void addUpdateBehavior( IMUpdateBehavior@ behavior, const string &in behaviorName );
    bool removeUpdateBehavior( const string &in behaviorName );
    bool hasUpdateBehavior(const string &in behaviorName);
    void clearUpdateBehaviors();
    void addMouseOverBehavior( IMMouseOverBehavior@ behavior, const string &in behaviorName );
    bool removeMouseOverBehavior( const string &in behaviorName );
    void clearMouseOverBehaviors();
    void addLeftMouseClickBehavior( IMMouseClickBehavior@ behavior, const string &in behaviorName );
    bool removeLeftMouseClickBehavior( const string &in behaviorName );
    void clearLeftMouseClickBehaviors();
    void sendMouseDownToChildren( bool send = true );
    void sendMouseOverToChildren( bool send = true );
    void setPauseBehaviors( bool pause );
    bool isMouseOver();
    void setName( const string &in _name );
    string getName();
    void setPadding( float U, float D, float L, float R);
    void setPaddingU( float paddingSize );
    void setPaddingD( float paddingSize );
    void setPaddingL( float paddingSize );
    void setPaddingR( float paddingSize );
    void setDisplacement( vec2 newDisplacement = vec2(0,0) );
    void setDisplacementX( float newDisplacement = 0 );
    void setDisplacementY( float newDisplacement = 0 );
    vec2 getDisplacement( vec2 newDisplacement = vec2(0,0) );
    float getDisplacementX();
    float getDisplacementY();
    void setDefaultSize( vec2 newDefault );
    vec2 getDefaultSize();
    void setSize( const vec2 _size );
    void setSizeX( const float x );
    void setSizeY( const float y );
    vec2 getSize();
    float getSizeX();
    float getSizeY();
    void sendMessage( IMMessage@ theMessage );
    IMElement@ findElement( const string &in elementName );
    IMElement@ getParent();
    void setMouseOver(bool hovered);
    IMImage@ opCast();
    IMElement@ opImplCast();
    IMImage@ f(const string &in name, DividerOrientation _orientation = DOVertical);
    void setSkipAspectFitting(bool val);
    void setCenter(bool val);
    void setImageFile( const string &in _fileName );
    void scaleToSizeX( float newSize );
    void scaleToSizeY( float newSize );
    void setRotation( float _rotation );
    float getRotation();
    void setImageOffset( vec2 offset, vec2 size );
class IMText {
    CItem controllerItem;
    void f();
    void f();
    string getElementTypeName();
    void setColor( vec4 _color );
    vec4 getColor();
    vec4 getBaseColor();
    void setEffectColor( vec4 _color );
    vec4 getEffectColor();
    void clearColorEffect();
    void setR( float value );
    float getR();
    void setG( float value );
    float getG();
    void setB( float value );
    float getB();
    void setAlpha( float value );
    float getAlpha();
    void setEffectR( float value );
    float getEffectR();
    void clearEffectR();
    void setEffectG( float value );
    float getEffectG();
    void clearEffectG();
    void setEffectB( float value );
    float getEffectB();
    void clearEffectB();
    void setEffectAlpha( float value );
    float getEffectAlpha();
    void clearEffectAlpha();
    void showBorder( bool _border = true );
    void setBorderSize( float _borderSize );
    void setBorderColor( vec4 _color );
    vec4 getBorderColor();
    void setBorderR( float value );
    float getBorderR();
    void setBorderG( float value );
    float getBorderG();
    void setBorderB( float value );
    float getBorderB();
    void setBorderAlpha( float value );
    float getBorderAlpha();
    void setZOrdering( int z );
    int getZOrdering();
    void renderAbove( IMElement@ element );
    void renderBelow( IMElement@ element );
    void setVisible( bool _show );
    void setClip( bool _clip );
    vec2 getScreenPosition();
    void addUpdateBehavior( IMUpdateBehavior@ behavior, const string &in behaviorName );
    bool removeUpdateBehavior( const string &in behaviorName );
    bool hasUpdateBehavior(const string &in behaviorName);
    void clearUpdateBehaviors();
    void addMouseOverBehavior( IMMouseOverBehavior@ behavior, const string &in behaviorName );
    bool removeMouseOverBehavior( const string &in behaviorName );
    void clearMouseOverBehaviors();
    void addLeftMouseClickBehavior( IMMouseClickBehavior@ behavior, const string &in behaviorName );
    bool removeLeftMouseClickBehavior( const string &in behaviorName );
    void clearLeftMouseClickBehaviors();
    void sendMouseDownToChildren( bool send = true );
    void sendMouseOverToChildren( bool send = true );
    void setPauseBehaviors( bool pause );
    bool isMouseOver();
    void setName( const string &in _name );
    string getName();
    void setPadding( float U, float D, float L, float R);
    void setPaddingU( float paddingSize );
    void setPaddingD( float paddingSize );
    void setPaddingL( float paddingSize );
    void setPaddingR( float paddingSize );
    void setDisplacement( vec2 newDisplacement = vec2(0,0) );
    void setDisplacementX( float newDisplacement = 0 );
    void setDisplacementY( float newDisplacement = 0 );
    vec2 getDisplacement( vec2 newDisplacement = vec2(0,0) );
    float getDisplacementX();
    float getDisplacementY();
    void setDefaultSize( vec2 newDefault );
    vec2 getDefaultSize();
    void setSize( const vec2 _size );
    void setSizeX( const float x );
    void setSizeY( const float y );
    vec2 getSize();
    float getSizeX();
    float getSizeY();
    void sendMessage( IMMessage@ theMessage );
    IMElement@ findElement( const string &in elementName );
    IMElement@ getParent();
    void setMouseOver(bool hovered);
    IMText@ opCast();
    IMElement@ opImplCast();
    IMText@ f(const string &in name);
    IMText@ f(const string &in _text, const string &in _fontName, int _fontSize, vec4 _color = vec4(1.0f));
    IMText@ f(const string &in _text, FontSetup _fontSetup);
    void setFont( FontSetup _fontSetup );
    void setFontByName( const string &in _fontName, int _fontSize );
    void setText( const string &in _text );
    string getText();
    void setShadowed( bool shouldShadow = true );
    void setRotation( float _rotation );
    float getRotation();
    void updateEngineTextObject();
class ScreenMetrics {
    vec2 GUISpace;
    vec2 screenSize;
    float GUItoScreenXScale;
    float GUItoScreenYScale;
    vec2 getMetrics();
    bool checkMetrics( vec2 &in metrics );
    void computeFactors();
    vec2 GUIToScreen( const vec2 pos );
    float getScreenWidth();
    float getScreenHeight();
ScreenMetrics screenMetrics;
class IMGUI {
    void f();
    void f();
    GUIState guistate;
    void setBackgroundLayers( uint numLayers );
    void setForegroundLayers( uint numLayers );
    void setHeaderHeight( float _headerSize );
    void setFooterHeight( float _footerSize );
    void setHeaderPanels( float first = 0, float second = 0, float third = 0 );
    void setMainPanels( float first = 0, float second = 0, float third = 0 );
    void setFooterPanels( float first = 0, float second = 0, float third = 0 );
    void setup();
    void clear();
    void setGuides( bool setting );
    void reportError( const string &in newError );
    void receiveMessage( IMMessage@ message );
    uint getMessageQueueSize();
    IMMessage@ getNextMessage();
    IMContainer@ getMain( uint panel = 0 );
    IMContainer@ getFooter( uint panel = 0 );
    IMContainer@ getHeader( uint panel = 0 );
    IMContainer@ getBackgroundLayer( uint layerNum = 0 );
    IMContainer@ getForegroundLayer( uint layerNum = 0 );
    void onRelayout();
    void update();
    void doScreenResize();
    void render();
    IMElement@ findElement( const string &in elementName );
    string getUniqueName( const string &in type = "Unkowntype");
    void drawBox( vec2 boxPos, vec2 boxSize, vec4 boxColor, int zOrder, bool shouldClip = false, vec2 currentClipPos = vec2(UNDEFINEDSIZE, UNDEFINEDSIZE), vec2 currentClipSize = vec2(UNDEFINEDSIZE, UNDEFINEDSIZE) );
IMGUI@ CreateIMGUI();
};
enum PlaceholderObjectType {
    kCamPreview = 1,
    kPlayerConnect = 2,
    kSpawn = 0,
class PlaceholderObject {
    void SetPreview(const string &in path);
    void SetBillboard(const string &in path);
    void SetSpecialType(int);
    void SetEditorDisplayName(const string &in name);
    int GetConnectID();
    uint64 GetConnectToTypeFilterFlags(); // Returns a bit mask, with EntityType for bit indices
    void SetConnectToTypeFilterFlags(uint64 flags); // Set a bit mask, with EntityType for bit indices
    void SetUnsavedChanges(bool changes);
    bool GetUnsavedChanges();
    PlaceholderObject@ opCast();
};
class TokenIterator {
    void Init();
    bool FindNextToken(const string& in);
    string GetToken(const string& in);
};
void Breakpoint(int);
bool LoadFile(const string &in);
string GetFileLine();
void StartWriteFile();
void AddFileString(const string &in);
bool WriteFile(const string &in);
bool WriteFileKeepBackup(const string &in);
bool WriteFileToWriteDir(const string &in);
string GetLocalizedDialoguePath(const string &in);
array<string>@ GetLocaleShortcodes();
array<string>@ GetLocaleNames();
string GetLocalizedLevelName(const string &in locale_shortcode, const string &in path);
class SavedChunk {
    void WriteString(const string &in str);
    string ReadString();
enum TextureLoadFlags {
    TextureLoadFlags_SRGB = 1,
    TextureLoadFlags_NoMipmap = 2,
    TextureLoadFlags_NoConvert = 4,
    TextureLoadFlags_NoLiveUpdate = 8,
    TextureLoadFlags_NoReduce = 16,
class TextureAssetRef {
    void TextureAssetRef();
    void TextureAssetRef(const TextureAssetRef &in other);
    void TextureAssetRef();
    bool IsValid();
    void Clear();
    TextureAssetRef& opAssign(const TextureAssetRef &in other);
    TextureAssetRef& opEquals(const TextureAssetRef &in other);
    TextureAssetRef& opCmp(const TextureAssetRef &in other);
TextureAssetRef LoadTexture(const string &in name, uint32 texture_load_flags = 0);
bool ImGui_Begin(const string &in name, int flags = 0); // bool ImGui_Begin(const string &in name, ImGuiWindowFlags flags = 0)
bool ImGui_Begin(const string &in name, bool &inout is_open, int flags = 0); // bool ImGui_Begin(const string &in name, bool &inout is_open, ImGuiWindowFlags flags = 0)
void ImGui_End();
bool ImGui_BeginChild(const string &in str_id, const vec2 &in size = vec2(0,0), bool border = false, int extra_flags = 0); // bool ImGui_BeginChild(const string &in str_id, const vec2 &in size = vec2(0,0), bool border = false, ImGuiWindowFlags extra_flags = 0)
bool ImGui_BeginChild(uint id, const vec2 &in size = vec2(0,0), bool border = false, int extra_flags = 0); // bool ImGui_BeginChild(uint id, const vec2 &in size = vec2(0,0), bool border = false, ImGuiWindowFlags extra_flags = 0)
void ImGui_EndChild();
vec2 ImGui_GetContentRegionMax();
vec2 ImGui_GetContentRegionAvail();
float ImGui_GetContentRegionAvailWidth();
vec2 ImGui_GetWindowContentRegionMin();
vec2 ImGui_GetWindowContentRegionMax();
float ImGui_GetWindowContentRegionWidth();
vec2 ImGui_GetWindowPos();
vec2 ImGui_GetWindowSize();
float ImGui_GetWindowWidth();
float ImGui_GetWindowHeight();
bool ImGui_IsWindowCollapsed();
bool ImGui_IsWindowAppearing();
void ImGui_SetWindowFontScale(float scale);
void ImGui_SetNextWindowPos(const vec2 &in pos, int cond = 0); // void ImGui_SetNextWindowPos(const vec2 &in pos, ImGuiSetCond cond = 0)
void ImGui_SetNextWindowPosCenter(int cond = 0); // void ImGui_SetNextWindowPosCenter(ImGuiSetCond cond = 0)
void ImGui_SetNextWindowSize(const vec2 &in size, int cond = 0); // void ImGui_SetNextWindowSize(const vec2 &in size, ImGuiSetCond cond = 0)
void ImGui_SetNextWindowContentSize(const vec2 &in size);
void ImGui_SetNextWindowContentWidth(float width);
void ImGui_SetNextWindowCollapsed(bool collapsed, int cond = 0); // void ImGui_SetNextWindowCollapsed(bool collapsed, ImGuiSetCond cond = 0)
void ImGui_SetNextWindowFocus();
void ImGui_SetWindowPos(const vec2 &in pos, int cond = 0); // void ImGui_SetWindowPos(const vec2 &in pos, ImGuiSetCond cond = 0)
void ImGui_SetWindowSize(const vec2 &in size, int cond = 0); // void ImGui_SetWindowSize(const vec2 &in size, ImGuiSetCond cond = 0)
void ImGui_SetWindowCollapsed(bool collapsed, int cond = 0); // void ImGui_SetWindowCollapsed(bool collapsed, ImGuiSetCond cond = 0)
void ImGui_SetWindowFocus();
void ImGui_SetWindowPos(const string &in name, const vec2 &in pos, int cond = 0); // void ImGui_SetWindowPos(const string &in name, const vec2 &in pos, ImGuiSetCond cond = 0)
void ImGui_SetWindowSize(const string &in name, const vec2 &in size, int cond = 0); // void ImGui_SetWindowSize(const string &in name, const vec2 &in size, ImGuiSetCond cond = 0)
void ImGui_SetWindowCollapsed(const string &in name, bool collapsed, int cond = 0); // void ImGui_SetWindowCollapsed(const string &in name, bool collapsed, ImGuiSetCond cond = 0)
void ImGui_SetWindowFocus(const string &in name);
float ImGui_GetScrollX();
float ImGui_GetScrollY();
float ImGui_GetScrollMaxX();
float ImGui_GetScrollMaxY();
void ImGui_SetScrollX(float scroll_x);
void ImGui_SetScrollY(float scroll_y);
void ImGui_SetScrollHere(float center_y_ratio = 0.5f);
void ImGui_SetScrollFromPosY(float pos_y, float center_y_ratio = 0.5f);
void ImGui_SetKeyboardFocusHere(int offset = 0);
void ImGui_PushStyleColor(int idx, const vec4 &in col); // void ImGui_PushStyleColor(ImGuiCol idx, const vec4 &in col)
void ImGui_PopStyleColor(int count = 1);
void ImGui_PushStyleVar(int idx, float val); // void ImGui_PushStyleVar(ImGuiStyleVar idx, float val)
void ImGui_PushStyleVar(int idx, const vec2 &in val); // void ImGui_PushStyleVar(ImGuiStyleVar idx, const vec2 &in val)
void ImGui_PushStyleVar(int idx, bool val); // void ImGui_PushStyleVar(ImGuiStyleVar idx, bool val)
void ImGui_PushStyleVar(int idx, int val); // void ImGui_PushStyleVar(ImGuiStyleVar idx, int val)
void ImGui_PopStyleVar(int count = 1);
vec4 ImGui_GetStyleColorVec4(int idx); // string ImGui_GetStyleColName(ImGuiCol idx)
uint32 ImGui_GetColorU32(uint32 idx, float alpha_mul = 1.0f); // uint32 GetColorU32(ImGuiCol idx, float alpha_mul = 1.0f)
uint32 ImGui_GetColorU32(const vec3 &in col);
uint32 ImGui_GetColorU32(const vec4 &in col);
uint32 ImGui_GetColorU32(float r, float g, float b, float alpha_mul = 1.0f);
void ImGui_PushItemWidth(float item_width);
void ImGui_PopItemWidth();
float ImGui_CalcItemWidth();
void ImGui_PushTextWrapPos(float wrap_pos_x = 0.0f);
void ImGui_PopTextWrapPos();
void ImGui_PushAllowKeyboardFocus(bool allow_keyboard_focus);
void ImGui_PopAllowKeyboardFocus();
void ImGui_PushButtonRepeat(bool repeat);
void ImGui_PopButtonRepeat();
void ImGui_Separator();
void ImGui_SameLine(float pos_x = 0.0, float spacing_w = -1.0);
void ImGui_NewLine();
void ImGui_Spacing();
void ImGui_Dummy(const vec2 &in size);
void ImGui_Indent(float indent_w = 0.0f);
void ImGui_Unindent(float indent_w = 0.0f);
void ImGui_BeginGroup();
void ImGui_EndGroup();
vec2 ImGui_GetCursorPos();
float ImGui_GetCursorPosX();
float ImGui_GetCursorPosY();
void ImGui_SetCursorPos(const vec2 &in local_pos);
void ImGui_SetCursorPosX(float x);
void ImGui_SetCursorPosY(float y);
vec2 ImGui_GetCursorStartPos();
vec2 ImGui_GetCursorScreenPos();
void ImGui_SetCursorScreenPos(const vec2 &in pos);
void ImGui_AlignFirstTextHeightToWidgets();
void ImGui_AlignTextToFramePadding();
float ImGui_GetTextLineHeight();
float ImGui_GetTextLineHeightWithSpacing();
float ImGui_GetItemsLineHeightWithSpacing();
float ImGui_GetFrameHeight();
float ImGui_GetFrameHeightWithSpacing();
bool ImGui_Columns(int count = 1, bool border = true);
bool ImGui_Columns(int count, const string &in id, bool border = true);
bool ImGui_NextColumn();
int ImGui_GetColumnIndex();
float ImGui_GetColumnOffset(int column_index = -1);
void ImGui_SetColumnOffset(int column_index, float offset_x);
float ImGui_GetColumnWidth(int column_index = -1);
float ImGui_SetColumnWidth(int column_index, float width);
int ImGui_GetColumnsCount();
void ImGui_Text(const string &in label); // Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
void ImGui_TextColored(const vec4 &in color, const string &in label); // Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
void ImGui_TextDisabled(const string &in label); // Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
void ImGui_TextWrapped(const string &in label); // Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
void ImGui_LabelText(const string &in str, const string &in label); // Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
void ImGui_Bullet();
void ImGui_BulletText(const string &in label); // Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
bool ImGui_Button(const string &in, const vec2 &in size = vec2(0,0));
bool ImGui_SmallButton(const string &in label);
bool ImGui_InvisibleButton(const string &in str_id, const vec2 &in size);
void ImGui_Image(const TextureAssetRef &in texture, const vec2 &in size, const vec2 &in uv0 = vec2(0,0), const vec2 &in uv1 = vec2(1,1), const vec4 &in tint_color = vec4(1,1,1,1), const vec4 &in border_color = vec4(0,0,0,0));
bool ImGui_ImageButton(const TextureAssetRef &in texture, const vec2 &in size, const vec2 &in uv0 = vec2(0,0), const vec2 &in uv1 = vec2(1,1), int frame_padding = -1, const vec4 &in background_color = vec4(0,0,0,0), const vec4 &in tint_color = vec4(1,1,1,1));
bool ImGui_Checkbox(const string &in label, bool &inout value);
bool ImGui_CheckboxFlags(const string &in label, uint &inout flags, uint flags_value);
bool ImGui_RadioButton(const string &in label, bool active);
bool ImGui_RadioButton(const string &in label, int &inout value, int v_button);
bool ImGui_BeginCombo(const string &in label, const string& in preview_value, int flags = 0); // bool ImGui_BeginCombo(const string &in label, const string& in preview_value, ImGuiComboFlags flags = 0)
void ImGui_EndCombo();
bool ImGui_Combo(const string &in label, int &inout current_item, const array<string> &in items, int popup_max_height_in_items = -1);
bool ImGui_Combo(const string &in label, int &inout current_item, const string &in items_separated_by_zeros, int popup_max_height_in_items = -1);
bool ImGui_DragFloat(const string &in label, float &inout value, float v_speed = 1.0f, float v_min = 0.0f, float v_max = 0.0f, const string &in display_format = "%.3f", float power = 1.0f);
bool ImGui_DragFloat2(const string &in label, vec2 &inout value, float v_speed = 1.0f, float v_min = 0.0f, float v_max = 0.0f, const string &in display_format = "%.3f", float power = 1.0f);
bool ImGui_DragFloat3(const string &in label, vec3 &inout value, float v_speed = 1.0f, float v_min = 0.0f, float v_max = 0.0f, const string &in display_format = "%.3f", float power = 1.0f);
bool ImGui_DragFloat4(const string &in label, vec4 &inout value, float v_speed = 1.0f, float v_min = 0.0f, float v_max = 0.0f, const string &in display_format = "%.3f", float power = 1.0f);
bool ImGui_DragFloatRange2(const string &in label, float &inout v_current_min, float &inout v_current_max, float v_speed = 1.0f, float v_min = 0.0f, float v_max = 0.0f, const string &in display_format = "%.3f");
bool ImGui_DragFloatRange2(const string &in label, float &inout v_current_min, float &inout v_current_max, float v_speed, float v_min, float v_max, const string &in display_format, const string &in display_format_max, float power = 1.0f);
bool ImGui_DragInt(const string &in label, int &inout value, float v_speed = 1.0f, int v_min = 0, int v_max = 0, const string &in display_format = "%.0f");
bool ImGui_DragInt2(const string &in label, ivec2 &inout value, float v_speed = 1.0f, int v_min = 0, int v_max = 0, const string &in display_format = "%.0f");
bool ImGui_DragInt3(const string &in label, ivec3 &inout value, float v_speed = 1.0f, int v_min = 0, int v_max = 0, const string &in display_format = "%.0f");
bool ImGui_DragInt4(const string &in label, ivec4 &inout value, float v_speed = 1.0f, int v_min = 0, int v_max = 0, const string &in display_format = "%.0f");
bool ImGui_DragIntRange2(const string &in label, int &inout v_current_min, int &inout v_current_max, float v_speed = 1.0f, int v_min = 0.0f, int v_max = 0.0f, const string &in display_format = "%.3f");
bool ImGui_DragIntRange2(const string &in label, int &inout v_current_min, int &inout v_current_max, float v_speed, int v_min, int v_max, const string &in display_format, const string &in display_format_max);
bool ImGui_InputText(const string &in label, int flags = 0); // bool ImGui_InputText(const string &in label, ImGuiInputTextFlags flags = 0)
bool ImGui_InputText(const string &in label, string &inout text_buffer, int buffer_size, int flags = 0); // bool ImGui_InputText(const string &in label, string &inout text_buffer, int buffer_size, ImGuiInputTextFlags flags = 0)
bool ImGui_InputTextMultiline(const string &in label, const vec2 &in size = vec2(0,0), int flags = 0); // bool ImGui_InputTextMultiline(const string &in label, const vec2 &in size = vec2(0,0), ImGuiInputTextFlags flags = 0)
bool ImGui_InputTextMultiline(const string &in label, string &inout text_buffer, int buffer_size, const vec2 &in size = vec2(0,0), int flags = 0); // bool ImGui_InputTextMultiline(const string &in label, string &inout text_buffer, int buffer_size, const vec2 &in size = vec2(0,0), ImGuiInputTextFlags flags = 0)
bool ImGui_InputFloat(const string &in label, float &inout value, float step = 0.0f, float step_fast = 0.0f, int decimal_precision = -1, int extra_flags = 0); // bool ImGui_InputFloat(const string &in label, float &inout value, float step = 0.0f, float step_fast = 0.0f, int decimal_precision = -1, ImGuiInputTextFlags extra_flags = 0)
bool ImGui_InputFloat2(const string &in label, vec2 &inout value, int decimal_precision = -1, int extra_flags = 0); // bool ImGui_InputFloat2(const string &in label, vec2 &inout value, int decimal_precision = -1, ImGuiInputTextFlags extra_flags = 0)
bool ImGui_InputFloat3(const string &in label, vec3 &inout value, int decimal_precision = -1, int extra_flags = 0); // bool ImGui_InputFloat3(const string &in label, vec3 &inout value, int decimal_precision = -1, ImGuiInputTextFlags extra_flags = 0)
bool ImGui_InputFloat4(const string &in label, vec4 &inout value, int decimal_precision = -1, int extra_flags = 0); // bool ImGui_InputFloat4(const string &in label, vec4 &inout value, int decimal_precision = -1, ImGuiInputTextFlags extra_flags = 0)
bool ImGui_InputInt(const string &in label, int &inout value, int step = 1, int step_fast = 100, int extra_flags = 0); // bool ImGui_InputInt(const string &in label, int &inout value, int step = 1, int step_fast = 100, ImGuiInputTextFlags extra_flags = 0)
bool ImGui_SliderFloat(const string &in label, float &inout v, float v_min, float v_max, const string &in display_format = "%.3f", float power = 1.0f);
bool ImGui_SliderFloat2(const string &in label, vec2 &inout v, float v_min, float v_max, const string &in display_format = "%.3f", float power = 1.0f);
bool ImGui_SliderFloat3(const string &in label, vec3 &inout v, float v_min, float v_max, const string &in display_format = "%.3f", float power = 1.0f);
bool ImGui_SliderFloat4(const string &in label, vec4 &inout v, float v_min, float v_max, const string &in display_format = "%.3f", float power = 1.0f);
bool ImGui_SliderAngle(const string &in label, float &inout v_rad, float v_degrees_min = -360.0f, float v_degrees_max = +360.0f);
bool ImGui_SliderInt(const string &in label, int &inout v, int v_min, int v_max, const string &in display_format = "%.0f");
bool ImGui_SliderInt2(const string &in label, ivec2 &inout v, int v_min, int v_max, const string &in display_format = "%.0f");
bool ImGui_SliderInt3(const string &in label, ivec3 &inout v, int v_min, int v_max, const string &in display_format = "%.0f");
bool ImGui_SliderInt4(const string &in label, ivec4 &inout v, int v_min, int v_max, const string &in display_format = "%.0f");
bool ImGui_ColorEdit3(const string &in label, vec3 &inout color, int flags = 0); // bool ImGui_ColorEdit3(const string &in label, vec3 &inout color, ImGuiColorEditFlags flags = 0
bool ImGui_ColorEdit4(const string &in label, vec4 &inout color, bool show_alpha = true);
bool ImGui_ColorEdit4(const string &in label, vec4 &inout color, int flags); // void ImGui_ColorEdit4(const string in& label, vec4 &inout color, ImGuiColorEditFlags flags = 0
bool ImGui_ColorPicker3(const string &in label, vec3 &inout color, int flags = 0); // bool ImGui_ColorPicker3(const string &in label, vec3 &inout color, ImGuiColorEditFlags flags = 0)
bool ImGui_ColorPicker4(const string &in label, vec4 &inout color, int flags = 0); // bool ImGui_ColorPicker4(const string &in label, vec4 &inout color, ImGuiColorEditFlags flags = 0)
bool ImGui_ColorPicker4(const string &in label, vec4 &inout color, int flags, vec4 ref_col); // bool ImGui_ColorPicker4(const string &in label, vec4 &inout color, ImGuiColorEditFlags flags, const vec4 &in ref_color)
bool ImGui_ColorButton(const vec4 &in col, bool small_height = false, bool outline_border = true);
bool ImGui_ColorButton(const string &in desc, const vec4 &in col, int flags = 0, const vec2 &in size = vec2(0, 0)); // bool ImGui_ColorButton(const string &in desc, const vec4 &in col, ImGuiColorEditFlags flags = 0, const vec2 &in size = vec2(0, 0)
void ImGui_ColorEditMode(int); // void ImGui_ColorEditMode(ImGuiColorEditMode mode)
bool ImGui_TreeNode(const string &in label);
bool ImGui_TreeNode(const string &in str_id, const string &in label); // Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
bool ImGui_TreeNode(const ? &in ptr_id, const string &in label); // Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
bool ImGui_TreeNodeEx(const string &in label, int flags = 0); // bool ImGui_TreeNodeEx(const string &in label, ImGuiTreeNodeFlags_ flags = 0)
bool ImGui_TreeNodeEx(const string &in str_id, int flags, const string &in label); // bool ImGui_TreeNodeEx(const string &in str_id, ImGuiTreeNodeFlags_ flags, const string &in label) - Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
bool ImGui_TreeNodeEx(const ? &in ptr_id, int flags, const string &in label); // bool ImGui_TreeNodeEx(const ? &in ptr_id, ImGuiTreeNodeFlags_ flags, const string &in label) - Note: label is not a format string, unlike in Dear ImGui. Use string concatenation instead
void ImGui_TreePush();
void ImGui_TreePush(const string &in str_id);
void ImGui_TreePush(const ? &in ptr_id);
void ImGui_TreePop();
void ImGui_TreeAdvanceToLabelPos();
float ImGui_GetTreeNodeToLabelSpacing();
void ImGui_SetNextTreeNodeOpen(bool is_open, int cond = 0); // void ImGui_SetNextTreeNodeOpen(bool is_open, ImGuiSetCond cond = 0)
bool ImGui_CollapsingHeader(const string &in label, int flags = 0); // bool ImGui_CollapsingHeader(const string &in label, ImGuiTreeNodeFlags flags = 0)
bool ImGui_CollapsingHeader(const string &in label, bool &inout is_open, int flags = 0); // bool ImGui_CollapsingHeader(const string &in label, bool &inout is_open, ImGuiTreeNodeFlags flags = 0)
bool ImGui_Selectable(const string &in label, bool selected = false, int flags = 0, const vec2 &in size = vec2(0,0)); // ImGui_Selectable(const string &in label, bool selected = false, ImGuiSelectableFlags flags = 0, const vec2& size = vec2(0,0))
bool ImGui_SelectableToggle(const string &in label, bool &inout selected, int flags = 0, const vec2 &in size = vec2(0,0)); // ImGui_SelectableToggle(const string &in label, bool &inout selected, ImGuiSelectableFlags flags = 0, const vec2& size = vec2(0,0))
bool ImGui_ListBox(const string &in label, int &inout current_item, const array<string> &in items, int height_in_items = -1);
bool ImGui_ListBoxHeader(const string &in label);
bool ImGui_ListBoxHeader(const string &in label, const vec2 &in size);
bool ImGui_ListBoxHeader(const string &in label, int items_count, int height_in_items = -1);
void ImGui_ListBoxFooter();
void ImGui_SetTooltip(const string &in text);
bool ImGui_BeginMenuBar();
void ImGui_EndMenuBar();
bool ImGui_BeginMenu(const string &in label, bool enabled = true);
void ImGui_EndMenu();
bool ImGui_MenuItem(const string &in label, bool selected = false, bool enabled = true);
void ImGui_OpenPopup(const string &in popup_id);
void ImGui_OpenPopupOnItemClick(const string &in popup_id, int mouse_button = 1);
bool ImGui_BeginPopup(const string &in popup_id);
bool ImGui_BeginPopupModal(const string &in name, int extra_flags = 0); // bool ImGui_BeginPopupModal(const string &in name, ImGuiWindowFlags extra_flags = 0)
bool ImGui_BeginPopupModal(const string &in name, bool &inout is_open, int extra_flags = 0); // bool ImGui_BeginPopupModal(const string &in name, bool &inout is_open, ImGuiWindowFlags extra_flags = 0)
bool ImGui_BeginPopupContextItem(const string &in popup_id, int mouse_button = 1);
bool ImGui_BeginPopupContextWindow(bool also_over_items = true, int mouse_button = 1);
bool ImGui_BeginPopupContextWindow(bool also_over_items, const string &in popup_id, int mouse_button = 1);
bool ImGui_BeginPopupContextVoid(int mouse_button = 1);
bool ImGui_BeginPopupContextVoid(const string &in popup_id, int mouse_button = 1);
void ImGui_EndPopup();
bool ImGui_IsPopupOpen(const string &in str_id);
void ImGui_CloseCurrentPopup();
bool ImGui_IsItemHovered();
bool ImGui_IsItemHoveredRect();
bool ImGui_IsItemActive();
bool ImGui_IsItemClicked(int mouse_button = 0);
bool ImGui_IsItemVisible();
bool ImGui_IsAnyItemHovered();
bool ImGui_IsAnyItemActive();
vec2 ImGui_GetItemRectMin();
vec2 ImGui_GetItemRectMax();
vec2 ImGui_GetItemRectSize();
void ImGui_SetItemAllowOverlap();
bool ImGui_IsWindowHovered();
bool ImGui_IsWindowFocused();
bool ImGui_IsRootWindowFocused();
bool ImGui_IsRootWindowOrAnyChildFocused();
bool ImGui_IsRootWindowOrAnyChildHovered();
bool ImGui_IsRectVisible(const vec2 &in size);
bool ImGui_IsRectVisible(const vec2 &in rect_min, const vec2 &in rect_max);
bool ImGui_IsPosHoveringAnyWindow(const vec2 &in pos);
bool ImGui_WantCaptureMouse();
float ImGui_GetTime();
int ImGui_GetFrameCount();
string ImGui_GetStyleColName(int idx); // string ImGui_GetStyleColName(ImGuiCol idx)
string ImGui_GetStyleColorName(int idx); // string ImGui_GetStyleColorName(ImGuiCol idx)
vec2 ImGui_CalcItemRectClosestPoint(const vec2 &in pos, bool on_edge = false, float outward = 0.0f);
vec2 ImGui_CalcTextSize(const string &in text, bool hide_text_after_double_hash = false, float wrap_width = -1.0f);
void ImGui_CalcListClipping(int items_count, float items_height, int &out out_items_display_start, int &out out_items_display_end);
bool ImGui_BeginChildFrame(uint id, const vec2 &in size, int extra_flags = 0); // bool ImGui_BeginChildFrame(uint id, const vec2 &in size, ImGuiWindowFlags extra_flags = 0)
void ImGui_EndChildFrame();
vec4 ImGui_ColorConvertU32ToFloat4(uint value);
uint ImGui_ColorConvertFloat4ToU32(const vec4 &in value);
void ImGui_ColorConvertRGBtoHSV(float r, float g, float b, float &out out_h, float &out out_s, float &out out_v);
void ImGui_ColorConvertHSVtoRGB(float h, float s, float v, float &out out_r, float &out out_g, float &out out_b);
int ImGui_GetKeyIndex(int imgui_key); // int ImGui_GetKeyIndex(ImGuiKey key)
bool ImGui_IsKeyDown(int key_index);
bool ImGui_IsKeyPressed(int key_index, bool repeat = true);
bool ImGui_IsKeyReleased(int key_index);
bool ImGui_IsMouseDown(int button);
bool ImGui_IsMouseClicked(int button, bool repeat = false);
bool ImGui_IsMouseDoubleClicked(int button);
bool ImGui_IsMouseReleased(int button);
bool ImGui_IsMouseHoveringWindow();
bool ImGui_IsMouseHoveringAnyWindow();
bool ImGui_IsMouseHoveringRect(const vec2 &in r_min, const vec2 &in r_max, bool clip = true);
bool ImGui_IsMouseDragging(int button = 0, float lock_threshold = -1.0f);
vec2 ImGui_GetMousePos();
vec2 ImGui_GetMousePosOnOpeningCurrentPopup();
vec2 ImGui_GetMouseDragDelta(int button = 0, float lock_threshold = -1.0f);
void ImGui_ResetMouseDragDelta(int button = 0);
int ImGui_GetMouseCursor(); // ImGuiMouseCursor ImGui_GetMouseCursor()
void ImGui_SetMouseCursor(int type); // void ImGui_SetMouseCursor(ImGuiMouseCursor type)
void ImGui_CaptureKeyboardFromApp(bool capture = true);
void ImGui_CaptureMouseFromApp(bool capture = true);
string ImGui_GetClipboardText();
void ImGui_SetClipboardText(const string &in value);
enum ImGuiWindowFlags_ {
    ImGuiWindowFlags_NoTitleBar = 1,
    ImGuiWindowFlags_NoResize = 2,
    ImGuiWindowFlags_NoMove = 4,
    ImGuiWindowFlags_NoScrollbar = 8,
    ImGuiWindowFlags_NoScrollWithMouse = 16,
    ImGuiWindowFlags_NoCollapse = 32,
    ImGuiWindowFlags_AlwaysAutoResize = 64,
    ImGuiWindowFlags_NoSavedSettings = 256,
    ImGuiWindowFlags_NoInputs = 512,
    ImGuiWindowFlags_MenuBar = 1024,
    ImGuiWindowFlags_HorizontalScrollbar = 2048,
    ImGuiWindowFlags_NoFocusOnAppearing = 4096,
    ImGuiWindowFlags_NoBringToFrontOnFocus = 8192,
    ImGuiWindowFlags_AlwaysVerticalScrollbar = 16384,
    ImGuiWindowFlags_AlwaysHorizontalScrollbar = 32768,
    ImGuiWindowFlags_AlwaysUseWindowPadding = 65536,
    ImGuiWindowFlags_ResizeFromAnySide = 131072,
enum ImGuiInputTextFlags_ {
    ImGuiInputTextFlags_CharsDecimal = 1,
    ImGuiInputTextFlags_CharsHexadecimal = 2,
    ImGuiInputTextFlags_CharsUppercase = 4,
    ImGuiInputTextFlags_CharsNoBlank = 8,
    ImGuiInputTextFlags_AutoSelectAll = 16,
    ImGuiInputTextFlags_EnterReturnsTrue = 32,
    ImGuiInputTextFlags_CallbackCompletion = 64,
    ImGuiInputTextFlags_CallbackHistory = 128,
    ImGuiInputTextFlags_CallbackAlways = 256,
    ImGuiInputTextFlags_CallbackCharFilter = 512,
    ImGuiInputTextFlags_AllowTabInput = 1024,
    ImGuiInputTextFlags_CtrlEnterForNewLine = 2048,
    ImGuiInputTextFlags_NoHorizontalScroll = 4096,
    ImGuiInputTextFlags_AlwaysInsertMode = 8192,
    ImGuiInputTextFlags_ReadOnly = 16384,
    ImGuiInputTextFlags_Password = 32768,
    ImGuiInputTextFlags_NoUndoRedo = 65536,
enum ImGuiTreeNodeFlags_ {
    ImGuiTreeNodeFlags_Selected = 1,
    ImGuiTreeNodeFlags_Framed = 2,
    ImGuiTreeNodeFlags_AllowOverlapMode = 4,
    ImGuiTreeNodeFlags_AllowItemOverlap = 4,
    ImGuiTreeNodeFlags_NoTreePushOnOpen = 8,
    ImGuiTreeNodeFlags_NoAutoOpenOnLog = 16,
    ImGuiTreeNodeFlags_DefaultOpen = 32,
    ImGuiTreeNodeFlags_OpenOnDoubleClick = 64,
    ImGuiTreeNodeFlags_OpenOnArrow = 128,
    ImGuiTreeNodeFlags_Leaf = 256,
    ImGuiTreeNodeFlags_Bullet = 512,
    ImGuiTreeNodeFlags_FramePadding = 1024,
    ImGuiTreeNodeFlags_CollapsingHeader = 18,
enum ImGuiSelectableFlags_ {
    ImGuiSelectableFlags_DontClosePopups = 1,
    ImGuiSelectableFlags_SpanAllColumns = 2,
    ImGuiSelectableFlags_AllowDoubleClick = 4,
enum ImGuiComboFlags_ {
    ImGuiComboFlags_PopupAlignLeft = 1,
    ImGuiComboFlags_HeightSmall = 2,
    ImGuiComboFlags_HeightRegular = 4,
    ImGuiComboFlags_HeightLarge = 8,
    ImGuiComboFlags_HeightLargest = 16,
enum ImGuiKey_ {
    ImGuiKey_Tab = 0,
    ImGuiKey_LeftArrow = 1,
    ImGuiKey_RightArrow = 2,
    ImGuiKey_UpArrow = 3,
    ImGuiKey_DownArrow = 4,
    ImGuiKey_PageUp = 5,
    ImGuiKey_PageDown = 6,
    ImGuiKey_Home = 7,
    ImGuiKey_End = 8,
    ImGuiKey_Delete = 9,
    ImGuiKey_Backspace = 10,
    ImGuiKey_Enter = 11,
    ImGuiKey_Escape = 12,
    ImGuiKey_A = 13,
    ImGuiKey_C = 14,
    ImGuiKey_V = 15,
    ImGuiKey_X = 16,
    ImGuiKey_Y = 17,
    ImGuiKey_Z = 18,
    ImGuiKey_COUNT = 22,
enum ImGuiCol_ {
    ImGuiCol_Text = 0,
    ImGuiCol_TextDisabled = 1,
    ImGuiCol_WindowBg = 2,
    ImGuiCol_ChildWindowBg = 3,
    ImGuiCol_ChildBg = 3,
    ImGuiCol_PopupBg = 4,
    ImGuiCol_Border = 5,
    ImGuiCol_BorderShadow = 6,
    ImGuiCol_FrameBg = 7,
    ImGuiCol_FrameBgHovered = 8,
    ImGuiCol_FrameBgActive = 9,
    ImGuiCol_TitleBg = 10,
    ImGuiCol_TitleBgCollapsed = 12,
    ImGuiCol_TitleBgActive = 11,
    ImGuiCol_MenuBarBg = 13,
    ImGuiCol_ScrollbarBg = 14,
    ImGuiCol_ScrollbarGrab = 15,
    ImGuiCol_ScrollbarGrabHovered = 16,
    ImGuiCol_ScrollbarGrabActive = 17,
    ImGuiCol_ComboBg = 4,
    ImGuiCol_CheckMark = 18,
    ImGuiCol_SliderGrab = 19,
    ImGuiCol_SliderGrabActive = 20,
    ImGuiCol_Button = 21,
    ImGuiCol_ButtonHovered = 22,
    ImGuiCol_ButtonActive = 23,
    ImGuiCol_Header = 24,
    ImGuiCol_HeaderHovered = 25,
    ImGuiCol_HeaderActive = 26,
    ImGuiCol_Column = 27,
    ImGuiCol_ColumnHovered = 28,
    ImGuiCol_ColumnActive = 29,
    ImGuiCol_ResizeGrip = 30,
    ImGuiCol_ResizeGripHovered = 31,
    ImGuiCol_ResizeGripActive = 32,
    ImGuiCol_CloseButton = 33,
    ImGuiCol_CloseButtonHovered = 34,
    ImGuiCol_CloseButtonActive = 35,
    ImGuiCol_PlotLines = 36,
    ImGuiCol_PlotLinesHovered = 37,
    ImGuiCol_PlotHistogram = 38,
    ImGuiCol_PlotHistogramHovered = 39,
    ImGuiCol_TextSelectedBg = 40,
    ImGuiCol_ModalWindowDarkening = 41,
    ImGuiCol_COUNT = 43,
enum ImGuiStyleVar_ {
    ImGuiStyleVar_Alpha = 0,
    ImGuiStyleVar_WindowPadding = 1,
    ImGuiStyleVar_WindowRounding = 2,
    ImGuiStyleVar_WindowMinSize = 4,
    ImGuiStyleVar_ChildWindowRounding = 5,
    ImGuiStyleVar_ChildRounding = 5,
    ImGuiStyleVar_FramePadding = 9,
    ImGuiStyleVar_FrameRounding = 10,
    ImGuiStyleVar_ItemSpacing = 12,
    ImGuiStyleVar_ItemInnerSpacing = 13,
    ImGuiStyleVar_IndentSpacing = 14,
    ImGuiStyleVar_GrabMinSize = 15,
    ImGuiStyleVar_ButtonTextAlign = 16,
    ImGuiStyleVar_Enabled = 17,
    ImGuiStyleVar_Count_ = 18,
enum ImGuiColorEditFlags_ {
    ImGuiColorEditFlags_NoAlpha = 2,
    ImGuiColorEditFlags_NoPicker = 4,
    ImGuiColorEditFlags_NoOptions = 8,
    ImGuiColorEditFlags_NoSmallPreview = 16,
    ImGuiColorEditFlags_NoInputs = 32,
    ImGuiColorEditFlags_NoTooltip = 64,
    ImGuiColorEditFlags_NoLabel = 128,
    ImGuiColorEditFlags_NoSidePreview = 256,
    ImGuiColorEditFlags_AlphaBar = 512,
    ImGuiColorEditFlags_AlphaPreview = 1024,
    ImGuiColorEditFlags_AlphaPreviewHalf = 2048,
    ImGuiColorEditFlags_HDR = 4096,
    ImGuiColorEditFlags_RGB = 8192,
    ImGuiColorEditFlags_HSV = 16384,
    ImGuiColorEditFlags_HEX = 32768,
    ImGuiColorEditFlags_Uint8 = 65536,
    ImGuiColorEditFlags_Float = 131072,
    ImGuiColorEditFlags_PickerHueBar = 262144,
    ImGuiColorEditFlags_PickerHueWheel = 524288,
enum ImGuiColorEditMode_ {
    ImGuiColorEditMode_UserSelect = -2,
    ImGuiColorEditMode_UserSelectShowButton = -1,
    ImGuiColorEditMode_RGB = 0,
    ImGuiColorEditMode_HSV = 1,
    ImGuiColorEditMode_HEX = 2,
enum ImGuiSetCond_ {
    ImGuiSetCond_Always = 1,
    ImGuiSetCond_Once = 2,
    ImGuiSetCond_FirstUseEver = 4,
    ImGuiSetCond_Appearing = 8,
void ImDrawList_AddLine(const vec2 &in a, const vec2 &in b, uint32 col, float thickness = 1.0f);
void ImDrawList_AddRect(const vec2 &in a, const vec2 &in b, uint32 col, float rounding = 0.0f, int rounding_corners_flags = 0xF, float thickness = 1.0f); // void ImDrawList_AddRect(const vec2 &in a, const vec2 &in b, uint32 col, float rounding = 0.0f, int rounding_corners_flags = ImDrawCornerFlags_All, float thickness = 1.0f) - a: upper-left, b: lower-right, rounding_corners_flags: 4-bits corresponding to which corner to round
void ImDrawList_AddRectFilled(const vec2 &in a, const vec2 &in b, uint32 col, float rounding = 0.0f, int rounding_corners_flags = 0xF); // void ImDrawList_AddRectFilled(const vec2 &in a, const vec2 &in b, uint32 col, float rounding = 0.0f, int rounding_corners_flags = ImDrawCornerFlags_All) - a: upper-left, b: lower-right
void ImDrawList_AddRectFilledMultiColor(const vec2 &in a, const vec2 &in b, uint32 col_upr_left, uint32 col_upr_right, uint32 col_bot_right, uint32 col_bot_left);
void ImDrawList_AddQuad(const vec2 &in a, const vec2 &in b, const vec2 &in c, const vec2 &in d, uint32 col, float thickness = 1.0f);
void ImDrawList_AddQuadFilled(const vec2 &in a, const vec2 &in b, const vec2 &in c, const vec2 &in d, uint32 col);
void ImDrawList_AddTriangle(const vec2 &in a, const vec2 &in b, const vec2 &in c, uint32 col, float thickness = 1.0f);
void ImDrawList_AddTriangleFilled(const vec2 &in a, const vec2 &in b, const vec2 &in c, uint32 col);
void ImDrawList_AddCircle(const vec2 &in center, float radius, uint32 col, int num_segments = 12, float thickness = 1.0f);
void ImDrawList_AddCircleFilled(const vec2 &in center, float radius, uint32 col, int num_segments = 12);
void ImDrawList_AddText(const vec2 &in pos, uint32 col, const string &in text);
void ImDrawList_AddImage(const TextureAssetRef &in texture, const vec2 &in a, const vec2 &in b, const vec2 &in uv_a = vec2(0, 0), const vec2 &in uv_b = vec2(1, 1), uint32 tint_color = 0xFFFFFFFF);
void ImDrawList_AddImageQuad(const TextureAssetRef &in texture, const vec2 &in a, const vec2 &in b, const vec2 &in c, const vec2 &in d, const vec2 &in uv_a = vec2(0, 0), const vec2 &in uv_b = vec2(1, 0), const vec2 &in uv_c = vec2(1, 1), const vec2 &in uv_d = vec2(0, 1), uint32 tint_color = 0xFFFFFFFF);
void ImDrawList_AddImageRounded(const TextureAssetRef &in texture, const vec2 &in a, const vec2 &in b, const vec2 &in uv_a, const vec2 &in uv_b, uint32 tint_color, float rounding, int rounding_corners = 0xF); // void ImDrawList_AddImageRounded(const TextureAssetRef &in texture, const vec2 &in a, const vec2 &in b, const vec2 &in uv_a, const vec2 &in uv_b, uint32 tint_color, float rounding, int rounding_corners = ImDrawCornerFlags_All)
void ImDrawList_AddBezierCurve(const vec2 &in pos0, const vec2 &in cp0, const vec2 &in cp1, const vec2 &in pos1, uint32 col, float thickness, int num_segments = 0);
void ImDrawList_PathClear();
void ImDrawList_PathLineTo(const vec2 &in pos);
void ImDrawList_PathLineToMergeDuplicate(const vec2 &in pos);
void ImDrawList_PathFillConvex(uint32 col);
void ImDrawList_PathStroke(uint32 col, bool closed, float thickness = 1.0f);
void ImDrawList_PathArcTo(const vec2 &in center, float radius, float a_min, float a_max, int num_segments = 10);
void ImDrawList_PathArcToFast(const vec2 &in center, float radius, int a_min_of_12, int a_max_of_12);
void ImDrawList_PathBezierCurveTo(const vec2 &in p1, const vec2 &in p2, const vec2 &in p3, int num_segments = 0);
void ImDrawList_PathRect(const vec2 &in rect_min, const vec2 &in rect_max, float rounding = 0.0f, int rounding_corners_flags = 0xF); // void ImDrawList_PathRect(const vec2 &in rect_min, const vec2 &in rect_max, float rounding = 0.0f, ImDrawCornerFlags rounding_corners_flags = ImDrawCornerFlags_All)
enum ImDrawCornerFlags_ {
    ImDrawCornerFlags_TopLeft = 1,
    ImDrawCornerFlags_TopRight = 2,
    ImDrawCornerFlags_BotLeft = 4,
    ImDrawCornerFlags_BotRight = 8,
    ImDrawCornerFlags_Top = 3,
    ImDrawCornerFlags_Bot = 12,
    ImDrawCornerFlags_Left = 5,
    ImDrawCornerFlags_Right = 10,
    ImDrawCornerFlags_All = 15,
string ImGui_GetTextBuf();
void ImGui_SetTextBuf(const string &in value);
int imgui_text_input_CursorPos;
int imgui_text_input_SelectionStart;
int imgui_text_input_SelectionEnd;
void ImGui_DrawSettings();
string GetUserPickedWritePath(const string &in suffix, const string &in default_path);
string GetUserPickedReadPath(const string &in suffix, const string &in default_path);
string FindShortestPath(const string &in path);
string FindFilePath(const string &in path);
IMImage@ ModGetThumbnailImage(ModID& sid);
class HUDImage {
    vec3 position;
    vec3 scale;
    vec2 tex_scale;
    vec2 tex_offset;
    vec4 color;
    float GetWidth() const;
    float GetHeight() const;
    bool SetImageFromPath(const string &in);
    void SetImageFromText(const TextCanvasTexture@);
};
class HUDImages {
    HUDImage@ AddImage();
    void Draw();
};
HUDImages hud;
class SavedLevel {
    void SetValue(const string &in key, const string &in value);
    const string& GetValue(const string &in key);
    void SetArrayValue(const string &in key, const int32 index, const string &in value);
    void DeleteArrayValue(const string &in key, const int32 index);
    void AppendArrayValueIfUnique(const string &in key, const string &in val);
    void AppendArrayValue(const string &in key, const string &in val);
    uint32 GetArraySize(const string &in key);
    string GetArrayValue(const string &in key, const int32 index);
    array<string>@ GetArray(const string &in key);
    void SetInt32Value(const string &in key, const int32 value);
    int32 GetInt32Value(const string &in key);
    bool HasInt32Value(const string &in key);
    void SetKey(const string &in modsource_id, const string &in campaign_name, const string &in level_name);
};
class SaveFile {
    SavedLevel& GetSavedLevel(const string &in name);
    SavedLevel& GetSave(const string campaign_id, const string save_category, const string save_name);
    bool SaveExist(const string modsource_id, const string save_category, const string save_name);
    bool WriteInPlace();
    void QueueWriteInPlace();
    uint GetLoadedVersion();
};
SaveFile save_file;
class CharacterScriptGetter { // Can load a character xml and provide access to its data
    bool Load(const string &in); // Load a character xml file (e.g. "Data/Characters/guard.xml")
    string GetObjPath();
    string GetSkeletonPath();
    string GetAnimPath(const string &in anim_label);
    const string& GetTag(const string &in key);
    string GetAttackPath(const string &in attack_label);
    void GetTeamString(string &out team_string);
    float GetHearing();
    const string& GetChannel(int which_channel); // Get type of given color channel (e.g. "fur", "cloth")
    bool GetMorphMetaPoints(const string &in label, vec3 &out start, vec3 &out end);
};
CharacterScriptGetter character_getter;
enum CollisionSides {
    DOUBLE_SIDED = 1,
    SINGLE_SIDED = 0,
};
class CollisionPoint {
    vec3 position;
    vec3 normal;
    vec3 custom_normal;
    int id;
    int tri;
};
class SphereCollision {
    vec3 position;
    vec3 adjusted_position;
    float radius;
    int NumContacts();
    CollisionPoint GetContact(int);
};
class ASCollisions {
    vec3 GetSlidingCapsuleCollision(vec3 start, vec3 end, float radius);
    void GetSlidingSphereCollision(vec3 pos, float radius);
    void GetSlidingSphereCollisionDoubleSided(vec3 pos, float radius);
    void GetScaledSphereCollision(vec3 pos, float radius, vec3 scale);
    void GetScaledSpherePlantCollision(vec3 pos, float radius, vec3 scale);
    void GetSlidingScaledSphereCollision(vec3 pos, float radius, vec3 scale);
    void GetCylinderCollision(vec3 pos, float radius, float height);
    void GetCylinderCollisionDoubleSided(vec3 pos, float radius, float height);
    void GetSweptSphereCollision(const vec3 &in start, const vec3 &in end, float radius);
    void GetSweptSphereCollisionCharacters(vec3 start, vec3 end, float radius);
    void GetSweptCylinderCollision(vec3 start, vec3 end, float radius, float height);
    void GetSweptCylinderCollisionDoubleSided(vec3 start, vec3 end, float radius, float height);
    void GetSweptBoxCollision(vec3 start, vec3 end, vec3 dimensions);
    void CheckRayCollisionCharacters(vec3 start, vec3 end);
    vec3 GetRayCollision(vec3 start, vec3 end);
    void GetObjRayCollision(vec3 start, vec3 end);
    void GetPlantRayCollision(vec3 start, vec3 end);
    void GetObjectsInSphere(vec3 pos, float radius);
};
ASCollisions col; // Used to access collision functions
SphereCollision sphere_col; // Stores results of collision functions
vec3 LineLineIntersect(vec3 start_a, vec3 end_a, vec3 start_b, vec3 end_b); // Get closest point between two line segments
